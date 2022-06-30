using System;

namespace UATPRapidPay.Card.Domain.Exceptions
{
    [Serializable]
    public class ExpirationDateFormatException : Exception
    {
        public ExpirationDateFormatException() : base($"Expiration Date is invalid")
        {
        }
    }
}