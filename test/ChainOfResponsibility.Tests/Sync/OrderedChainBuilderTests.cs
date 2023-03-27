using AutoFixture;
using ChainOfResponsibility.Interfaces.Sync;
using ChainOfResponsibility.Sync;
using ChainOfResponsibility.Tests.Models;
using Core.Interfaces;
using FluentAssertions;
using Moq;

namespace ChainOfResponsibility.Tests.Sync
{
    [TestFixture]
    public class OrderedChainBuilderTests
    {
        protected Mock<IContext<UnitOfWork>> ContextMock = new();
        protected Parameter Parameter = new();
        protected Result Result = new();

        [SetUp]
        public void SetUp()
        {
            ContextMock = new Mock<IContext<UnitOfWork>>();
            var fixture = new Fixture();
            Parameter = fixture.Create<Parameter>();
            Result = fixture.Create<Result>();
        }

        [Test]
        public void Build_EmptyChain_ReturnsResult()
        {
            // GIVEN an empty chain of handlers
            var (chainBuilder, _) = InitializeChainOf(0);

            // WHEN the chain is built
            var chain = chainBuilder.Build(ContextMock.Object);

            // AND the chain is executed
            var result = chain.Execute(Parameter, Result);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);
        }

        [Test]
        public void Build_SingleChain_ReturnsResult()
        {
            // GIVEN an chain of one handler
            var (chainBuilder, mocks) = InitializeChainOf(1);

            // WHEN the chain is built
            var chain = chainBuilder.Build(ContextMock.Object);

            // AND the chain is executed
            var result = chain.Execute(Parameter, Result);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);

            // AND the handler method should have been called.
            mocks.Should().HaveCount(1);
            mocks.Single().Verify(m => m.Handle(ContextMock.Object, Parameter, Result), Times.Once);
        }

        [Test]
        public void Build_ThreeChain_ReturnsResult()
        {
            // GIVEN an chain of one handler
            var (chainBuilder, mocks) = InitializeChainOf(3);

            // WHEN the chain is built
            var chain = chainBuilder.Build(ContextMock.Object);

            // AND the chain is executed
            var result = chain.Execute(Parameter, Result);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);

            // AND the handler methods should have been called.
            mocks.Should().HaveCount(3);
            foreach (var mock in mocks)
            {
                mock.Verify(m => m.Handle(ContextMock.Object, Parameter, Result), Times.Once);
            }
        }

        protected (OrderedChainBuilder<UnitOfWork, Parameter, Result> chainBuilder,
            List<Mock<IOrderedHandler<UnitOfWork, Parameter, Result>>> mocks) InitializeChainOf(int length)
        {
            var mocks = Enumerable.Range(1, length)
                .Select(InitializeHandler)
                .ToList();
            var chainBuilder =
                new OrderedChainBuilder<UnitOfWork, Parameter, Result>(mocks.Select(m => m.Object));
            return (chainBuilder, mocks);
        }

        protected Mock<IOrderedHandler<UnitOfWork, Parameter, Result>> InitializeHandler(int order)
        {
            var mock = new Mock<IOrderedHandler<UnitOfWork, Parameter, Result>>();
            mock.Setup(m => m.Order).Returns(order);
            mock.Setup(m => m.SetNext(It.IsAny<IHandler<UnitOfWork, Parameter, Result>>()))
                .Callback((IHandler<UnitOfWork, Parameter, Result> next) => mock
                    .Setup(m => m
                        .Handle(It.IsAny<IContext<UnitOfWork>>(), It.IsAny<Parameter>(), It.IsAny<Result>()))
                    .Returns((IContext<UnitOfWork> c, Parameter p, Result r) => next.Handle(c, p, r)));
            return mock;
        }
    }
}
