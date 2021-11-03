using Domain.RapidPay.Entities;
using System;
namespace InterfaceAdapters.RapidPay.Models
{
    public class PaymentResponse
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }

        public static explicit operator PaymentResponse(Payment v)
        {
            if (v == null)
                return null;

            return new PaymentResponse()
            {
                Amount = v.Amount,
                Date = v.Date,
                Fee = v.Fee
            };
        }
    }
}