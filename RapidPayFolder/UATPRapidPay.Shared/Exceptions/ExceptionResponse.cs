using System.Net;

namespace UATPRapidPay.Shared.Exceptions
{
    public class ExceptionResponse
    {
        public ExceptionResponse(HttpStatusCode statusCode, object response)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public HttpStatusCode StatusCode { get; set; }

        public object Response { get; set; }
    }
}