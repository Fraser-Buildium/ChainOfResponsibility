namespace Core.Errors
{
    //As talked with Kevin, maybe we need to think about a better name for this class or even if it is needed
    //at this time this is only wrapping ValidationResponse
    public class ValidationError : Error
    {
        public ValidationResponse ValidationResponse { get; }

        public ValidationError(string message) : base(message)
        {

        }

        public ValidationError(string message, ValidationResponse validationResponse) : this(message)
        {
            ValidationResponse = validationResponse;
        }
    }
}