using System.Net;
using Core;

namespace ChainOfResponsibility.Tests.Models
{
    public class Result : IResult
    {
        public ResultCode? StatusCode { get; set; } = HttpStatusCode.OK;
        public int ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
