using System;

namespace UATPRapidPay.Card.Application.Exceptions
{
    internal abstract class AppException : Exception
    {
        public virtual string Code { get; set; }

        public AppException(string message) : base(message)
        {

        }
    }
}