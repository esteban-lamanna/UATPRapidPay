using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Domain.Exceptions
{
    public class EmailFormatException : DomainException
    {
        public EmailFormatException() : base($"The email format is incorrect.")
        {
        }
    }
}