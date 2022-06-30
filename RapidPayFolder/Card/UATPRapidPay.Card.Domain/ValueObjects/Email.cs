using System;
using System.Text.RegularExpressions;
using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record Email
    {
        private const string EMAIL_REGEX = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public Email(string email)
        {
            Value = email;
            ValidateFormat(email);
        }

        private static void ValidateFormat(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new CardFormatException();

            var isValid = Regex.IsMatch(email, EMAIL_REGEX, RegexOptions.IgnoreCase);
            if(!isValid)
                throw new CardFormatException();
        }

        public string Value { get; set; }

        public static implicit operator Email(string email)
        {
            return new Email(email);
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}