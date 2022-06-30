namespace UATPRapidPay.Card.Domain.Exceptions
{
    internal class CardFormatException : DomainException
    {
        internal CardFormatException() : base($"The card number format is incorrect.")
        {
        }

        public override string Code { get => "100"; }
    }
}