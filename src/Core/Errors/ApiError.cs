namespace Core.Errors
{
    public class ApiError
    {
        public ApiError(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Error key, such as a field name or
        /// a permission type e.g. "First Name"
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// Error value such as a field specific validation
        /// failure e.g. "First name must be provided"
        /// </summary>
        public string Value { get; }

        public override int GetHashCode()
        {
            return
                Hashcode.Start.Hash(Key)
                    .Hash(Value);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ApiError))
            {
                return false;
            }
            return GetHashCode() == obj.GetHashCode();
        }
    }
}