using System;
using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record ExpirationDate
    {
        public ExpirationDate(DateOnly date)
        {
            ValidateFormat(date);
            Value = date;
        }

        public DateOnly Value { get; protected set; }

        private static void ValidateFormat(DateOnly date)
        {
            var now = DateOnly.FromDateTime(DateTime.UtcNow.Date);

            var twoYearsTime = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2).Date);

            var isValid = now < date &&
                          twoYearsTime < date;

            if (!isValid)
                throw new ExpirationDateFormatException();
        }

        public static implicit operator ExpirationDate(DateOnly date)
        {
            return new ExpirationDate(date);
        }

        public static implicit operator DateOnly(ExpirationDate name)
        {
            return name.Value;
        }
    }
}