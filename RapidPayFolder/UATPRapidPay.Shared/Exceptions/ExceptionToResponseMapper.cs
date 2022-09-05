using System;
using System.Net;

namespace UATPRapidPay.Shared.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
        {
            switch (exception)
            {
                case DomainException:
                    return new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message);

                case ApplicationException:
                    return new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message);

                default:
                    return new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message);
            }
        }
    }
}