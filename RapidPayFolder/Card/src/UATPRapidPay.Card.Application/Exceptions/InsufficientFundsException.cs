using System;

namespace UATPRapidPay.Card.Application.Exceptions
{
    internal class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException() : base($"Insufficient funds")
        {
        }
    }
}