using ChainOfResponsibility.Interfaces.Sync;
using ChainOfResponsibility.Sync;
using ChainOfResponsibility.Tests.Models;
using Core;
using Core.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace ChainOfResponsibility.Tests.Sync
{
    [TestFixture]
    public class IsolatingHandlerTests
    {
        protected Mock<ILoggerFactory> LoggerFactoryMock = new();
        protected Mock<ILogger> LoggerMock = new();
        protected Mock<IContext<UnitOfWork>> Context = new();
        protected Parameter Parameter = new();
        protected Result Result = new();

        protected Mock<IInitiatoryHandler<UnitOfWork, Parameter, Result>> SunnyDayMock = new();
        protected Mock<IInitiatoryHandler<UnitOfWork, Parameter, Result>> ErrorResultMock = new();
        protected Mock<IInitiatoryHandler<UnitOfWork, Parameter, Result>> CancelledMock = new();

        protected IsolatingHandler<UnitOfWork, Parameter, Result> IsolatingHandler;

        [SetUp]
        public void Setup()
        {
            LoggerFactoryMock.Setup(x => x.CreateLogger(It.IsAny<string>()))
                .Returns(LoggerMock.Object);
            
            Context = new Mock<IContext<UnitOfWork>>();
            Parameter = new Parameter();
            Result = new Result();
            SunnyDayMock = new Mock<IInitiatoryHandler<UnitOfWork, Parameter, Result>>();
            ErrorResultMock = new Mock<IInitiatoryHandler<UnitOfWork, Parameter, Result>>();
            CancelledMock = new Mock<IInitiatoryHandler<UnitOfWork, Parameter, Result>>();

            IsolatingHandler = new IsolatingHandler<UnitOfWork, Parameter, Result>(LoggerFactoryMock.Object);
        }

        [Test]
        public void IsolatingHandler_WrappingSunnyDay_ReturnsSuccess()
        {
            // GIVEN a sunny day synchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.Handle(Context.Object, Parameter, Result))
                .Returns(Result);

            // AND an isolating synchronous handler wrapping it
            IsolatingHandler.SetWrapped(SunnyDayMock.Object);

            // WHEN the isolating synchronous handler is asked to handle the request.
            var result = IsolatingHandler.Handle(Context.Object, Parameter, Result);

            // THEN the sunny day handler method should be called
            SunnyDayMock.Verify(x => x.Handle(Context.Object, Parameter, Result), Times.Once);

            // AND the result should be the expected result.
            result.Should().BeEquivalentTo(Result);
        }

        [Test]
        public void IsolatingHandler_PrecedesSunnyDay_ReturnsSuccess()
        {
            // GIVEN a sunny day synchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.Handle(Context.Object, Parameter, Result))
                .Returns(Result);

            // AND an isolating synchronous handler is configured to call it next
            IsolatingHandler.SetNext(SunnyDayMock.Object);

            // WHEN the isolating synchronous handler is asked to handle the request.
            var result = IsolatingHandler.Handle(Context.Object, Parameter, Result);

            // THEN the sunny day handler method should be called
            SunnyDayMock.Verify(x => x.Handle(Context.Object, Parameter, Result), Times.Once);

            // AND the result should be the expected result.
            result.Should().BeEquivalentTo(Result);
        }

        [Test]
        public void IsolatingHandler_WrapAttemptAfterNextSet_ThrowsInvalidOperationException()
        {
            // GIVEN a sunny day synchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.Handle(Context.Object, Parameter, Result))
                .Returns(Result);

            // AND an isolating synchronous handler is configured to call it next
            IsolatingHandler.SetNext(SunnyDayMock.Object);

            // WHEN the isolating synchronous handler is configured to wrap
            var setWrapped = () => IsolatingHandler.SetWrapped(SunnyDayMock.Object);

            // THEN the attempt will throw an invalid operation exception
            setWrapped.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot wrap a handler, if the NextHandler is already set.");
        }

        [Test]
        public void IsolatingHandler_TwoWrapAttempts_ThrowsInvalidOperationException()
        {
            // GIVEN a sunny day synchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.Handle(Context.Object, Parameter, Result))
                .Returns(Result);

            // AND an isolating synchronous handler is configured to call it next
            IsolatingHandler.SetWrapped(SunnyDayMock.Object);

            // WHEN the isolating synchronous handler is configured to wrap
            var setWrapped = () => IsolatingHandler.SetWrapped(SunnyDayMock.Object);

            // THEN the attempt will throw an invalid operation exception
            setWrapped.Should().Throw<InvalidOperationException>()
                .WithMessage("Wrapped handler previously specified.");
        }

        [Test]
        public void IsolatingHandler_WrappedException_ReturnsErrorResult()
        {
            // GIVEN a canceled synchronous handler throws an OperationCanceledException
            ErrorResultMock
                .Setup(x => x.Handle(Context.Object, Parameter, Result))
                .Throws(new Exception());

            // AND an isolating synchronous handler wrapping it
            IsolatingHandler.SetWrapped(ErrorResultMock.Object);

            // WHEN the isolating synchronous handler is asked to handle the request.
            var result = IsolatingHandler
                .Handle(Context.Object, Parameter, Result);

            // THEN the canceled synchronous handler method should be called
            ErrorResultMock
                .Verify(x => x.Handle(Context.Object, Parameter, Result),
                    Times.Once);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.InternalServerError);
            result.Message.Should().Be("An unexpected error occurred.");
        }

        [Test]
        public void IsolatingHandler_NextException_ReturnsErrorResult()
        {
            // GIVEN a canceled synchronous handler throws an OperationCanceledException
            ErrorResultMock
                .Setup(x => x.Handle(Context.Object, Parameter, Result))
                .Throws(new Exception());

            // AND an isolating synchronous handler precedes it
            IsolatingHandler.SetNext(ErrorResultMock.Object);

            // WHEN the isolating synchronous handler is asked to handle the request
            var result = IsolatingHandler
                .Handle(Context.Object, Parameter, Result);

            // THEN the canceled synchronous handler method should be called
            ErrorResultMock
                .Verify(x => x.Handle(Context.Object, Parameter, Result),
                    Times.Once);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.InternalServerError);
            result.Message.Should().Be("An unexpected error occurred.");
        }
    }
}