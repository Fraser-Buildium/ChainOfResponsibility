namespace Core.Errors
{
    public class ReportServiceError : Error
    {
        public string Type { get; set; }
        
        public ReportServiceError(string message) : base(message)
        {
        }

        public ReportServiceError(string message, string type) : base(message)
        {
            Type = type;
        }
    }
}