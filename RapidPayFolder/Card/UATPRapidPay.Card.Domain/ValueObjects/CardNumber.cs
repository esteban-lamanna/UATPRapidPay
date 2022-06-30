using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record CardNumber
    {
        public CardNumber(string number)
        {
            Number = number;
            ValidateFormat(number);
        }

        private static void ValidateFormat(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new CardFormatException();

            if (number.Length != 16)
                throw new CardFormatException();
        }

        public string Number { get; set; }

        public static implicit operator CardNumber(string number)
        {
            return new CardNumber(number);
        }

        public static implicit operator string(CardNumber cardNumber)
        {
            return cardNumber.Number;
        }
    }
}