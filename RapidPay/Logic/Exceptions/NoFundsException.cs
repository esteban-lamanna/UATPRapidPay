using System;
using System.Globalization;

namespace RapidPay.Logic.Exceptions
{
    public class NoFundsException : Exception
    {
        public NoFundsException() : base() { }

        public NoFundsException(string message) : base(message) { }

        public NoFundsException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}