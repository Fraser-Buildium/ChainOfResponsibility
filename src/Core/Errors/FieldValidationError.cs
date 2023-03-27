namespace Core.Errors
{
    public class FieldValidationError
    {
        public string FieldName { get; }
        public string ErrorMessage { get; }
        public string ErrorCode { get; }

        public FieldValidationError(string fieldName, string errorMessage, string errorCode)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public override bool Equals(object obj)
        {
            return obj is FieldValidationError o &&
                   FieldName == o.FieldName &&
                   ErrorMessage == o.ErrorMessage &&
                   ErrorCode == o.ErrorCode;
        }

        public override int GetHashCode()
        {
            return Hashcode.Start
                .Hash(FieldName)
                .Hash(ErrorMessage)
                .Hash(ErrorCode);
        }
    }
}