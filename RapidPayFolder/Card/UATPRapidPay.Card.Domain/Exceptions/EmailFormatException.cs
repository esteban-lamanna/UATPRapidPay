namespace UATPRapidPay.Card.Domain.Exceptions
{
    internal class EmailFormatException : DomainException
    {
        public EmailFormatException() : base($"The email format is incorrect.")
        {
        }

        public override string Code { get => "101"; }
    }
}