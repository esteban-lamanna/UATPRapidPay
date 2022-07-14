using System;

namespace UATPRapidPay.Shared.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        protected ApplicationException(string message) : base(message)
        {
        }
    }
}