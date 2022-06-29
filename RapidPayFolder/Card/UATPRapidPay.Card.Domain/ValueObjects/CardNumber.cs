namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public class CardNumber
    {
        public CardNumber(string number)
        {
            Number = number;
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