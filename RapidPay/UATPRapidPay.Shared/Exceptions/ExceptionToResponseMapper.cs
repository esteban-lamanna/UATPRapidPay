using System;
using System.Net;
using UATPRapidPay.Shared.Extensions;

namespace UATPRapidPay.Shared.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
        {
            switch (exception)
            {
                case DomainException:
                    return new ExceptionResponse(HttpStatusCode.BadRequest, GetResponseBody(exception));

                case ApplicationException:
                    return new ExceptionResponse(HttpStatusCode.BadRequest, GetResponseBody(exception));

                default:
                    return new ExceptionResponse(HttpStatusCode.BadRequest, GetResponseBody(exception));
            }
        }

        private static object GetResponseBody(Exception exception)
        {
            return new
            {
                Message = exception.Message,
                Code = GetCode(exception),
            };
        }

        private static string GetCode(Exception exception)
        {
            switch (exception)
            {
                case DomainException ex:
                    var typeName = ex.GetType().Name;
                    return !string.IsNullOrEmpty(ex.Code) ? ex.Code.ToString() : GetSnakeString(typeName);
                    
                case ApplicationException ex:
                    var typeName2 = ex.GetType().Name;
                    return !string.IsNullOrEmpty(ex.Code) ? ex.Code.ToString() : GetSnakeString(typeName2);

                default:
                    return GetSnakeString(exception.GetType().Name);
            }
        }

        private static string GetSnakeString(string exceptionName)
        {
            return exceptionName.Underscore().Replace("_exception", string.Empty);
        }
    }
}