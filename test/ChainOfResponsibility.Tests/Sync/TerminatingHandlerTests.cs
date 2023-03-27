using ChainOfResponsibility.Sync;
using ChainOfResponsibility.Tests.Models;
using Core;
using Core.Interfaces;
using FluentAssertions;
using Moq;

namespace ChainOfResponsibility.Tests.Sync
{
    [TestFixture]
    public class TerminatingHandlerTests
    {
        protected Mock<IContext<UnitOfWork>> Context = new();
        protected Parameter Parameter = new();
        protected Result Result = new();

        protected TerminatingHandler<UnitOfWork, Parameter, Result> TerminatingHandler = new();

        [SetUp]
        public void Setup()
        {
            Context = new Mock<IContext<UnitOfWork>>();
            Parameter = new Parameter();
            Result = new Result();

            TerminatingHandler = new TerminatingHandler<UnitOfWork, Parameter, Result>();
        }

        [Test]
        public void TerminatingHandler_OkResult_ReturnsResult()
        {
            // GIVEN a result with a Ok status
            Result = new Result
            {
                StatusCode = ResultCode.OK
            };

            // WHEN the terminating handler is used
            var result = TerminatingHandler.Handle(Context.Object, Parameter, Result);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);
            result.StatusCode.Should().BeEquivalentTo<ResultCode>(ResultCode.OK);
        }

        [Test]
        public void TerminatingHandler_InternalServerErrorResult_ReturnsResult()
        {
            // GIVEN a result with an internal server error status
            Result = new Result
            {
                StatusCode = ResultCode.InternalServerError,
                Message = "An unexpected error occurred."
            };

            // WHEN the terminating handler is used
            var result = TerminatingHandler.Handle(Context.Object, Parameter, Result);

            // THEN the result matches
            result.Should().BeEquivalentTo(Result);
            result.StatusCode.Should().BeEquivalentTo<ResultCode>(ResultCode.InternalServerError);
            result.Message.Should().BeEquivalentTo("An unexpected error occurred.");
        }
    }
}
