namespace Domain.RapidPay.DTO
{
    public class CreateCardDTO
    {
        public string Number { get; set; }
        public decimal Limit { get; set; }
        public int IdUser { get; set; }
    }
}