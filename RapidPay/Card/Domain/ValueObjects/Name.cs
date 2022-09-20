using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record Name
    {
        public Name(string name)
        {
            Value = name;
            ValidateFormat(name);
        }

        private static void ValidateFormat(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new NameFormatException();
        }

        public string Value { get; init; }

        public static implicit operator Name(string name)
        {
            return new Name(name);
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }
    }
}