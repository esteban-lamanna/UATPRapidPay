using System;
using System.Globalization;

namespace RapidPay.EnterpriseBusinessRules.Exceptions
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException() : base() { }

        public ConcurrencyException(string message) : base(message) { }

        public ConcurrencyException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}