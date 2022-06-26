using System;

namespace UATPRapidPay.Domain.Exceptions
{
    internal abstract class DomainException : Exception
    {
        public virtual string Code { get; set; }

        protected DomainException(string message) : base(message)
        {
        }
    }
}