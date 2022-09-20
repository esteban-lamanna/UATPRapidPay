using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record Price
    {
        public Price(decimal Price)
        {
            Value = Price;
            ValidateFormat(Price);
        }

        private static void ValidateFormat(decimal Price)
        {
            if (Price < 0)
                throw new PriceMustBeGreatherOrEqualToZeroException();
        }

        public decimal Value { get; init; }

        public static implicit operator Price(decimal Price)
        {
            return new Price(Price);
        }

        public static implicit operator decimal(Price Price)
        {
            return Price.Value;
        }
    }
}