using System;

namespace UATPRapidPay.Shared.Exceptions
{
    public abstract class DomainException : Exception
    {
        public virtual string Code { get; set; }

        public DomainException(string message) : base(message)
        {
        }
    }
}