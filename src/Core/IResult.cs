namespace Core
{
    public interface IResult 
    {
        ResultCode StatusCode { get; set; }
        int ErrorCode { get; set; }
        string? Message { get; set; }
    }
}
