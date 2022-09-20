using System;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record PurchaseDate
    {
        public PurchaseDate(DateTime date)
        {
            Value = date;
        }

        public DateTime Value { get; init; }

        public static implicit operator PurchaseDate(DateTime date)
        {
            return new PurchaseDate(date);
        }

        public static implicit operator DateTime(PurchaseDate name)
        {
            return name.Value;
        }
    }
}