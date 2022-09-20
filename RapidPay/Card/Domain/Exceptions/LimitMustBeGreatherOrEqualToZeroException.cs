using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Domain.Exceptions
{
    internal class LimitMustBeGreatherOrEqualToZeroException : DomainException
    {
        internal LimitMustBeGreatherOrEqualToZeroException() : base($"The limit must be greather than 0.")
        {
        }
    }
}