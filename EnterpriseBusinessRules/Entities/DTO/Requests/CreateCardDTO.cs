namespace RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests
{
    public class CreateCardDTO
    {
        public string Number { get; set; }
        public decimal Limit { get; set; }
        public int IdUser { get; set; }
    }
}