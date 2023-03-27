using ChainOfResponsibility.Async;
using ChainOfResponsibility.Interfaces.Async;
using ChainOfResponsibility.Tests.Models;
using Core;
using Core.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace ChainOfResponsibility.Tests.Async
{
    [TestFixture]
    public class IsolatingAsyncHandlerTests
    {
        protected Mock<ILoggerFactory> LoggerFactoryMock = new();
        protected Mock<ILogger> LoggerMock = new();
        protected Mock<IAsyncContext<UnitOfWork>> Context = new();
        protected Parameter Parameter = new();
        protected Result Result = new();

        protected Mock<IInitiatoryAsyncHandler<UnitOfWork, Parameter, Result>> SunnyDayMock = new();
        protected Mock<IInitiatoryAsyncHandler<UnitOfWork, Parameter, Result>> ErrorResultMock = new();
        protected Mock<IInitiatoryAsyncHandler<UnitOfWork, Parameter, Result>> CancelledMock = new();

        protected IsolatingAsyncHandler<UnitOfWork, Parameter, Result> IsolatingAsyncHandler;

        [SetUp]
        public void Setup()
        {
            LoggerFactoryMock.Setup(x => x.CreateLogger(It.IsAny<string>()))
                .Returns(LoggerMock.Object);
            
            Context = new Mock<IAsyncContext<UnitOfWork>>();
            Parameter = new Parameter();
            Result = new Result();
            SunnyDayMock = new Mock<IInitiatoryAsyncHandler<UnitOfWork, Parameter, Result>>();
            ErrorResultMock = new Mock<IInitiatoryAsyncHandler<UnitOfWork, Parameter, Result>>();
            CancelledMock = new Mock<IInitiatoryAsyncHandler<UnitOfWork, Parameter, Result>>();

            IsolatingAsyncHandler = new IsolatingAsyncHandler<UnitOfWork, Parameter, Result>(LoggerFactoryMock.Object);
        }

        [Test]
        public async Task IsolatingAsyncHandler_WrappingSunnyDay_ReturnsSuccess()
        {
            // GIVEN a sunny day asynchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ReturnsAsync(Result);

            // AND an isolating asynchronous handler wrapping it
            IsolatingAsyncHandler.SetWrapped(SunnyDayMock.Object);

            // WHEN the isolating asynchronous handler is asked to handle the request.
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the sunny day handler method should be called
            SunnyDayMock.Verify(x => x.HandleAsync(Context.Object, Parameter, Result), Times.Once);

            // AND the result should be the expected result.
            result.Should().BeEquivalentTo(Result);
        }

        [Test]
        public async Task IsolatingAsyncHandler_PrecedesSunnyDay_ReturnsSuccess()
        {
            // GIVEN a sunny day asynchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ReturnsAsync(Result);

            // AND an isolating asynchronous handler is configured to call it next
            IsolatingAsyncHandler.SetNext(SunnyDayMock.Object);

            // WHEN the isolating asynchronous handler is asked to handle the request.
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the sunny day handler method should be called
            SunnyDayMock.Verify(x => x.HandleAsync(Context.Object, Parameter, Result), Times.Once);

            // AND the result should be the expected result.
            result.Should().BeEquivalentTo(Result);
        }

        [Test]
        public void IsolatingAsyncHandler_WrapAttemptAfterNextSet_ThrowsInvalidOperationException()
        {
            // GIVEN a sunny day asynchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ReturnsAsync(Result);

            // AND an isolating asynchronous handler is configured to call it next
            IsolatingAsyncHandler.SetNext(SunnyDayMock.Object);

            // WHEN the isolating asynchronous handler is configured to wrap
            var setWrapped = () => IsolatingAsyncHandler.SetWrapped(SunnyDayMock.Object);

            // THEN the attempt will throw an invalid operation exception
            setWrapped.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot wrap a handler, if the NextHandler is already set.");
        }

        [Test]
        public void IsolatingAsyncHandler_TwoWrapAttempts_ThrowsInvalidOperationException()
        {
            // GIVEN a sunny day asynchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ReturnsAsync(Result);

            // AND an isolating asynchronous handler is configured to call it next
            IsolatingAsyncHandler.SetWrapped(SunnyDayMock.Object);

            // WHEN the isolating asynchronous handler is configured to wrap
            var setWrapped = () => IsolatingAsyncHandler.SetWrapped(SunnyDayMock.Object);

            // THEN the attempt will throw an invalid operation exception
            setWrapped.Should().Throw<InvalidOperationException>()
                .WithMessage("Wrapped handler previously specified.");
        }

        [Test]
        public async Task IsolatingAsyncHandler_WrappedWithCanceledContext_WillNotCallInnerHandler()
        {
            // GIVEN a sunny day asynchronous handler that returns a successful result
            SunnyDayMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ReturnsAsync(Result);

            // AND an isolating asynchronous handler wrapping it
            IsolatingAsyncHandler.SetWrapped(SunnyDayMock.Object);

            // AND the the request has been canceled
            Context.Setup(x => x.CancellationToken).Returns(new CancellationToken(true));

            // WHEN the isolating asynchronous handler is asked to handle the request.
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the sunny day handler method should NOT be called
            SunnyDayMock
                .Verify(x => x.HandleAsync(Context.Object, Parameter, Result),
                    Times.Never);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.BadRequest);
            result.Message.Should().Be("Client closed request.");
        }

        [Test]
        public async Task IsolatingAsyncHandler_WrappedCanceled_ReturnsCancellationResult()
        {
            // GIVEN a canceled asynchronous handler throws an OperationCanceledException
            CancelledMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ThrowsAsync(new OperationCanceledException());

            // AND an isolating asynchronous handler wrapping it
            IsolatingAsyncHandler.SetWrapped(CancelledMock.Object);

            // WHEN the isolating asynchronous handler is asked to handle the request.
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the canceled asynchronous handler method should be called
            CancelledMock
                .Verify(x => x.HandleAsync(Context.Object, Parameter, Result),
                    Times.Once);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.BadRequest);
            result.Message.Should().Be("Client closed request.");
        }

        [Test]
        public async Task IsolatingAsyncHandler_NextCanceled_ReturnsCancellationResult()
        {
            // GIVEN a canceled asynchronous handler throws an OperationCanceledException
            CancelledMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ThrowsAsync(new OperationCanceledException());

            // AND an isolating asynchronous handler precedes it
            IsolatingAsyncHandler.SetNext(CancelledMock.Object);

            // WHEN the isolating asynchronous handler is asked to handle the request
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the canceled asynchronous handler method should be called
            CancelledMock
                .Verify(x => x.HandleAsync(Context.Object, Parameter, Result),
                    Times.Once);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.BadRequest);
            result.Message.Should().Be("Client closed request.");
        }

        [Test]
        public async Task IsolatingAsyncHandler_WrappedException_ReturnsErrorResult()
        {
            // GIVEN a canceled asynchronous handler throws an OperationCanceledException
            ErrorResultMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ThrowsAsync(new Exception());

            // AND an isolating asynchronous handler wrapping it
            IsolatingAsyncHandler.SetWrapped(ErrorResultMock.Object);

            // WHEN the isolating asynchronous handler is asked to handle the request.
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the canceled asynchronous handler method should be called
            ErrorResultMock
                .Verify(x => x.HandleAsync(Context.Object, Parameter, Result),
                    Times.Once);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.InternalServerError);
            result.Message.Should().Be("An unexpected error occurred.");
        }

        [Test]
        public async Task IsolatingAsyncHandler_NextException_ReturnsErrorResult()
        {
            // GIVEN a canceled asynchronous handler throws an OperationCanceledException
            ErrorResultMock
                .Setup(x => x.HandleAsync(Context.Object, Parameter, Result))
                .ThrowsAsync(new Exception());

            // AND an isolating asynchronous handler precedes it
            IsolatingAsyncHandler.SetNext(ErrorResultMock.Object);

            // WHEN the isolating asynchronous handler is asked to handle the request
            var result = await IsolatingAsyncHandler
                .HandleAsync(Context.Object, Parameter, Result)
                .ConfigureAwait(false);

            // THEN the canceled asynchronous handler method should be called
            ErrorResultMock
                .Verify(x => x.HandleAsync(Context.Object, Parameter, Result),
                    Times.Once);

            // AND the result should reflected a cancellation
            result.StatusCode.Should().NotBeNull().And.BeEquivalentTo<ResultCode>(ResultCode.InternalServerError);
            result.Message.Should().Be("An unexpected error occurred.");
        }
    }
}