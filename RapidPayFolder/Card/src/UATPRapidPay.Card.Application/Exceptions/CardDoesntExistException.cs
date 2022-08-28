using System;

namespace UATPRapidPay.Card.Application.Exceptions
{
    public class CardDoesntExistException : ApplicationException
    {
        public CardDoesntExistException(string cardNumber) : base($"Card with number {cardNumber} doesn't exist.")
        {
        }
    }
}