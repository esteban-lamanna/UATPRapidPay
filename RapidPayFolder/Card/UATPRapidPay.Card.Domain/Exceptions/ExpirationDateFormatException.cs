using System;
using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Domain.Exceptions
{
    [Serializable]
    public class ExpirationDateFormatException : DomainException
    {
        public ExpirationDateFormatException() : base($"Expiration Date is invalid")
        {
        }
    }
}