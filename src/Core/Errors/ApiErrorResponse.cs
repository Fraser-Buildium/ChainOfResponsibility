namespace Core.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(string userMessage, string errorCode = null, IEnumerable<ApiError> errors = null)
        {
            UserMessage = userMessage;
            ErrorCode = errorCode;

            Errors = errors ?? Enumerable.Empty<ApiError>();
        }

        /// <summary>
        /// Client visible message describing the error
        /// </summary>
        public string UserMessage { get; }
        /// <summary>
        /// Optional specialized error code, this is
        /// not an HTTP status code
        /// </summary>
        public string ErrorCode { get; }
        /// <summary>
        /// Key value pair collection of specific error information
        /// </summary>
        public IEnumerable<ApiError> Errors { get; }
    }
}