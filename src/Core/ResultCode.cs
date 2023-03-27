using System.Net;

namespace Core
{
    public sealed class ResultCode
    {
        public ResultCode()
        {
            Value = (int) HttpStatusCode.OK;
        }

        public ResultCode(int value)
        {
            Value = value;
        }

        public readonly int Value;

        public static implicit operator ResultCode(HttpStatusCode statusCode)
        {
            return new ResultCode((int) statusCode);
        }

        public static implicit operator ResultCode(int httpStatusCode)
        {
            return new ResultCode(httpStatusCode);
        }

        public bool IsSuccessful => Value is >= 200 and <= 299;

        // Informational 1xx
        public const int Continue = (int) HttpStatusCode.Continue;
        public const int SwitchingProtocols = (int) HttpStatusCode.SwitchingProtocols;
        public const int Processing = (int) HttpStatusCode.Processing;
        public const int EarlyHints = (int) HttpStatusCode.EarlyHints;

        // Successful 2xx
        public const int OK = (int) HttpStatusCode.OK;
        public const int Created = (int) HttpStatusCode.Created;
        public const int Accepted = (int) HttpStatusCode.Accepted;
        public const int NonAuthoritativeInformation = (int) HttpStatusCode.NonAuthoritativeInformation;
        public const int NoContent = (int) HttpStatusCode.NoContent;
        public const int ResetContent = (int) HttpStatusCode.ResetContent;
        public const int PartialContent = (int) HttpStatusCode.PartialContent;
        public const int MultiStatus = (int) HttpStatusCode.MultiStatus;
        public const int AlreadyReported = (int) HttpStatusCode.AlreadyReported;

        public const int IMUsed = (int) HttpStatusCode.IMUsed;

        // Redirection 3xx
        public const int MultipleChoices = (int) HttpStatusCode.MultipleChoices;
        public const int Ambiguous = (int) HttpStatusCode.Ambiguous;
        public const int MovedPermanently = (int) HttpStatusCode.MovedPermanently;
        public const int Moved = (int) HttpStatusCode.Moved;
        public const int Found = (int) HttpStatusCode.Found;
        public const int Redirect = (int) HttpStatusCode.Redirect;
        public const int SeeOther = (int) HttpStatusCode.SeeOther;
        public const int RedirectMethod = (int) HttpStatusCode.RedirectMethod;
        public const int NotModified = (int) HttpStatusCode.NotModified;
        public const int UseProxy = (int) HttpStatusCode.UseProxy;
        public const int Unused = (int) HttpStatusCode.Unused;
        public const int TemporaryRedirect = (int) HttpStatusCode.TemporaryRedirect;
        public const int RedirectKeepVerb = (int) HttpStatusCode.RedirectKeepVerb;
        public const int PermanentRedirect = (int) HttpStatusCode.PermanentRedirect;

        // Client Error 4xx
        public const int BadRequest = (int) HttpStatusCode.BadRequest;
        public const int Unauthorized = (int) HttpStatusCode.Unauthorized;
        public const int PaymentRequired = (int) HttpStatusCode.PaymentRequired;
        public const int Forbidden = (int) HttpStatusCode.Forbidden;
        public const int NotFound = (int) HttpStatusCode.NotFound;
        public const int MethodNotAllowed = (int) HttpStatusCode.MethodNotAllowed;
        public const int NotAcceptable = (int) HttpStatusCode.NotAcceptable;
        public const int ProxyAuthenticationRequired = (int) HttpStatusCode.ProxyAuthenticationRequired;
        public const int RequestTimeout = (int) HttpStatusCode.RequestTimeout;
        public const int Conflict = (int) HttpStatusCode.Conflict;
        public const int Gone = (int) HttpStatusCode.Gone;
        public const int LengthRequired = (int) HttpStatusCode.LengthRequired;
        public const int PreconditionFailed = (int) HttpStatusCode.PreconditionFailed;
        public const int RequestEntityTooLarge = (int) HttpStatusCode.RequestEntityTooLarge;
        public const int RequestUriTooLong = (int) HttpStatusCode.RequestUriTooLong;
        public const int UnsupportedMediaType = (int) HttpStatusCode.UnsupportedMediaType;
        public const int RequestedRangeNotSatisfiable = (int) HttpStatusCode.RequestedRangeNotSatisfiable;
        public const int ExpectationFailed = (int) HttpStatusCode.ExpectationFailed;

        // From https://github.com/dotnet/runtime/issues/15650:
        // "It would be a mistake to add it to .NET now. See golang/go#21326,
        // nodejs/node#14644, requests/requests#4238 and aspnet/HttpAbstractions#915".
        // ImATeapot = 418

        public const int MisdirectedRequest = (int) HttpStatusCode.MisdirectedRequest;
        public const int UnprocessableEntity = (int) HttpStatusCode.UnprocessableEntity;
        public const int Locked = (int) HttpStatusCode.Locked;
        public const int FailedDependency = (int) HttpStatusCode.FailedDependency;

        public const int UpgradeRequired = (int) HttpStatusCode.UpgradeRequired;

        public const int PreconditionRequired = (int) HttpStatusCode.PreconditionRequired;
        public const int TooManyRequests = (int) HttpStatusCode.TooManyRequests;

        public const int RequestHeaderFieldsTooLarge = (int) HttpStatusCode.RequestHeaderFieldsTooLarge;

        public const int UnavailableForLegalReasons = (int) HttpStatusCode.UnavailableForLegalReasons;

        public const int ClosedByClient = 499;

        // Server Error 5xx
        public const int InternalServerError = (int) HttpStatusCode.InternalServerError;
        public const int NotImplemented = (int) HttpStatusCode.NotImplemented;
        public const int BadGateway = (int) HttpStatusCode.BadGateway;
        public const int ServiceUnavailable = (int) HttpStatusCode.ServiceUnavailable;
        public const int GatewayTimeout = (int) HttpStatusCode.GatewayTimeout;
        public const int HttpVersionNotSupported = (int) HttpStatusCode.HttpVersionNotSupported;
        public const int VariantAlsoNegotiates = (int) HttpStatusCode.VariantAlsoNegotiates;
        public const int InsufficientStorage = (int) HttpStatusCode.InsufficientStorage;
        public const int LoopDetected = (int) HttpStatusCode.LoopDetected;

        public const int NotExtended = (int) HttpStatusCode.NotExtended;
        public const int NetworkAuthenticationRequired = (int) HttpStatusCode.NetworkAuthenticationRequired;
    }
}
