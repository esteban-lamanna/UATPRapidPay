using System;

namespace UATPRapidPay.Shared.Exceptions
{
    public interface IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception);
    }
}