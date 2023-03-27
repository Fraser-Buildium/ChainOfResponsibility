namespace Core.Errors
{
    public class UnauthorizedError : Error
    {
        public UnauthorizedError(string message, string errorCode = null) : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; }
    }
}