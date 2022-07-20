using System.Collections.Generic;

namespace RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses
{
    public class GetBalanceDTO
    {
        public IEnumerable<GetPaymentDTO> Payments { get; set; }
        public decimal? Available { get; set; }
        public decimal? Limit { get; set; }
    }
}