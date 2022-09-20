using UATPRapidPay.Card.Domain.Exceptions;

namespace UATPRapidPay.Card.Domain.ValueObjects
{
    public record ProductName
    {
        public ProductName(string name)
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

        public static implicit operator ProductName(string name)
        {
            return new ProductName(name);
        }

        public static implicit operator string(ProductName name)
        {
            return name.Value;
        }
    }
}