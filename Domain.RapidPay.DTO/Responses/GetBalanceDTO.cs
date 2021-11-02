using System.Collections.Generic;

namespace Domain.RapidPay.DTO
{
    public class GetBalanceDTO
    {
        public IEnumerable<GetPaymentDTO> Payments { get; set; }
        public decimal? Available { get; set; }
        public decimal? Limit { get; set; }
    }
}