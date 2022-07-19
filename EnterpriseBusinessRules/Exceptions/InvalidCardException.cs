using System;
using System.Globalization;

namespace RapidPay.EnterpriseBusinessRules.Exceptions
{
    public class InvalidCardException : Exception
    {
        public InvalidCardException() : base() { }

        public InvalidCardException(string message) : base(message) { }

        public InvalidCardException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}