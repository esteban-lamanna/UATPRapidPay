using System.Collections.Generic;

namespace RapidPay.Models
{
    public class GetBalanceResponse
    {
        public IEnumerable<PaymentResponse> Payments { get; set; }

    }
}