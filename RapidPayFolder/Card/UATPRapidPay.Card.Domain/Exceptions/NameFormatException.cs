using System;

namespace UATPRapidPay.Card.Domain.Exceptions
{
    [Serializable]
    internal class NameFormatException : DomainException
    {
        public NameFormatException() : base($"Name is incorrect.")
        {
        }
    }
}