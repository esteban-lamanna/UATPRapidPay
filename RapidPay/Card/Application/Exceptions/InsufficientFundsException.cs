using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Application.Exceptions
{
    internal class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException() : base($"Insufficient funds")
        {
        }
    }
}