using AutoFixture;
using ChainOfResponsibility.Async;
using ChainOfResponsibility.Interfaces.Async;
using ChainOfResponsibility.Tests.Models;
using Core.Abstractions.Interfaces;
using FluentAssertions;
using Moq;

namespace ChainOfResponsibility.Tests.Async
{
    [TestFixture]
    public class OrderedAsyncChainBuilderTests
    {
        protected Mock<IAsyncContext<UnitOfWork>> ContextMock = new();
        protected Parameter Parameter = new();
        protected Result Result = new();

        [SetUp]
        public void SetUp()
        {
            ContextMock = new Mock<IAsyncContext<UnitOfWork>>();
            var fixture = new Fixture();
            Parameter = fixture.Create<Parameter>();
            Result = fixture.Create<Result>();
        }

        [Test]
        public async Task Build_EmptyChain_ReturnsResult()
        {
            // GIVEN an empty chain of handlers
            var (chainBuilder, _) = InitializeChainOf(0);

            // WHEN the chain is built
            var chain = chainBuilder.Build(ContextMock.Object);

            // AND the chain is executed
            var result = await chain.ExecuteAsync(Parameter, Result).ConfigureAwait(false);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);
        }

        [Test]
        public async Task Build_SingleChain_ReturnsResult()
        {
            // GIVEN an chain of one handler
            var (chainBuilder, mocks) = InitializeChainOf(1);

            // WHEN the chain is built
            var chain = chainBuilder.Build(ContextMock.Object);

            // AND the chain is executed
            var result = await chain.ExecuteAsync(Parameter, Result).ConfigureAwait(false);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);

            // AND the handler method should have been called.
            mocks.Should().HaveCount(1);
            mocks.Single().Verify(m => m.HandleAsync(ContextMock.Object, Parameter, Result), Times.Once);
        }

        [Test]
        public async Task Build_ThreeChain_ReturnsResult()
        {
            // GIVEN an chain of one handler
            var (chainBuilder, mocks) = InitializeChainOf(3);

            // WHEN the chain is built
            var chain = chainBuilder.Build(ContextMock.Object);

            // AND the chain is executed
            var result = await chain.ExecuteAsync(Parameter, Result).ConfigureAwait(false);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);

            // AND the handler methods should have been called.
            mocks.Should().HaveCount(3);
            foreach (var mock in mocks)
            {
                mock.Verify(m => m.HandleAsync(ContextMock.Object, Parameter, Result), Times.Once);
            }
        }

        [Test]
        public void Build_LoopedChain_ThrowsException()
        {
            // GIVEN a looped chain of handlers
            var mock = InitializeHandler(1);
            var mocks = new List<Mock<IOrderedAsyncHandler<UnitOfWork, Parameter, Result>>> {mock, mock};

            // WHEN the chain builder is constructed
            var chainBuilder = () => 
                new OrderedAsyncChainBuilder<UnitOfWork, Parameter, Result>(mocks.Select(m => m.Object));

            // THEN the operation throws an error
            chainBuilder.Should().Throw<InvalidOperationException>()
                .WithMessage($"Loop detected on {mock.Object.GetType()}! Chain of responsibility should not have duplicate instances.");
        }

        protected (OrderedAsyncChainBuilder<UnitOfWork, Parameter, Result> chainBuilder,
            List<Mock<IOrderedAsyncHandler<UnitOfWork, Parameter, Result>>> mocks) InitializeChainOf(int length)
        {
            var mocks = Enumerable.Range(1, length)
                .Select(InitializeHandler)
                .ToList();
            var chainBuilder =
                new OrderedAsyncChainBuilder<UnitOfWork, Parameter, Result>(mocks.Select(m => m.Object));
            return (chainBuilder, mocks);
        }

        protected Mock<IOrderedAsyncHandler<UnitOfWork, Parameter, Result>> InitializeHandler(int order)
        {
            var mock = new Mock<IOrderedAsyncHandler<UnitOfWork, Parameter, Result>>();
            mock.Setup(m => m.Order).Returns(order);
            mock.Setup(m => m.SetNext(It.IsAny<IAsyncHandler<UnitOfWork, Parameter, Result>>()))
                .Callback((IAsyncHandler<UnitOfWork, Parameter, Result> next) => mock
                    .Setup(m => m
                        .HandleAsync(It.IsAny<IAsyncContext<UnitOfWork>>(), It.IsAny<Parameter>(), It.IsAny<Result>()))
                    .Returns(async (IAsyncContext<UnitOfWork> c, Parameter p, Result r) => await next.HandleAsync(c, p, r)));
            return mock;
        }
    }
}
