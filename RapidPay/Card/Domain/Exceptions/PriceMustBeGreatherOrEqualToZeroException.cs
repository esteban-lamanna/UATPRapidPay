using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Domain.Exceptions
{
    internal class PriceMustBeGreatherOrEqualToZeroException : DomainException
    {
        internal PriceMustBeGreatherOrEqualToZeroException() : base($"The price must be greather than 0.")
        {
        }
    }
}