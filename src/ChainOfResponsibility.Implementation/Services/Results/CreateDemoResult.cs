using ChainOfResponsibility.Data.Models;
using ChainOfResponsibility.Data.Models.Subscriber;
using Core;

namespace ChainOfResponsibility.Implementation.Services.Results
{
    public class CreateDemoResult : IResult
    {
        public CreateDemoResult()
        {
            StatusCode = ResultCode.OK;
        }

        public ResultCode StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string? Message { get; set; }

        public Demo? Entity { get; set; }
    }
}
