using System;
using System.Globalization;

namespace RapidPay.EnterpriseBusinessRules.Exceptions
{
    public class CardNumberInUseException : Exception
    {
        public CardNumberInUseException() : base() { }

        public CardNumberInUseException(string message) : base(message) { }

        public CardNumberInUseException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}