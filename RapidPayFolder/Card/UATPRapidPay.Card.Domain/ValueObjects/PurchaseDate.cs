using System;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record PurchaseDate
    {
        public PurchaseDate(DateTime date)
        {
            ValidateFormat(date);
            Value = date;
        }

        public DateTime Value { get; init; }

        private static void ValidateFormat(DateTime date)
        {
            //var now = DateOnly.FromDateTime(DateTime.UtcNow.Date);

            //var twoYearsTime = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(2).Date);

            //var isValid = now < date &&
            //              twoYearsTime < date;

            //if (!isValid)
            //    throw new ExpirationDateFormatException();
        }
    }
}