using ChainOfResponsibility.Async;
using ChainOfResponsibility.Tests.Models;
using Core;
using Core.Abstractions.Interfaces;
using FluentAssertions;
using Moq;

namespace ChainOfResponsibility.Tests.Async
{
    [TestFixture]
    public class TerminatingAsyncHandlerTests
    {
        protected Mock<IAsyncContext<UnitOfWork>> Context = new();
        protected Parameter Parameter = new();
        protected Result Result = new();

        protected TerminatingAsyncHandler<UnitOfWork, Parameter, Result> TerminatingHandler = new();

        [SetUp]
        public void Setup()
        {
            Context = new Mock<IAsyncContext<UnitOfWork>>();
            Parameter = new Parameter();
            Result = new Result();

            TerminatingHandler = new TerminatingAsyncHandler<UnitOfWork, Parameter, Result>();
        }

        [Test]
        public async Task TerminatingHandler_OkResult_ReturnsResult()
        {
            // GIVEN a result with a Ok status
            Result = new Result
            {
                StatusCode = ResultCode.OK
            };

            // WHEN the terminating handler is used
            var result = await TerminatingHandler.HandleAsync(Context.Object, Parameter, Result).ConfigureAwait(false);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);
            result.StatusCode.Should().BeEquivalentTo<ResultCode>(ResultCode.OK);
        }

        [Test]
        public async Task TerminatingHandler_InternalServerErrorResult_ReturnsResult()
        {
            // GIVEN a result with an internal server error status
            Result = new Result
            {
                StatusCode = ResultCode.InternalServerError,
                Message = "An unexpected error occurred."
            };

            // WHEN the terminating handler is used
            var result = await TerminatingHandler.HandleAsync(Context.Object, Parameter, Result).ConfigureAwait(false);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);
            result.StatusCode.Should().BeEquivalentTo<ResultCode>(ResultCode.InternalServerError);
            result.Message.Should().BeEquivalentTo("An unexpected error occurred.");
        }
    }
}
