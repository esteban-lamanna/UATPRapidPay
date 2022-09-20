using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record Limit
    {
        public Limit(decimal limit)
        {
            Value = limit;
            ValidateFormat(limit);
        }

        private static void ValidateFormat(decimal limit)
        {
            if (limit < 0)
                throw new LimitMustBeGreatherOrEqualToZeroException();
        }

        public decimal Value { get; init; }

        public static implicit operator Limit(decimal limit)
        {
            return new Limit(limit);
        }

        public static implicit operator decimal(Limit limit)
        {
            return limit.Value;
        }
    }
}