using System;

namespace UATPRapidPay.Shared.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        public virtual string Code { get; set; }

        protected ApplicationException(string message) : base(message)
        {
        }
    }
}