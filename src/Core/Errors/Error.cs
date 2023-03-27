namespace Core.Errors
{
    public class Error
    {
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }

        public override bool Equals(object obj) => obj is Error dto
                                                   && dto.Message == Message;

        public override int GetHashCode() => Hashcode.Start
            .Hash(Message);
    }
}