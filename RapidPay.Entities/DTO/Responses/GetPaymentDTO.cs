namespace Domain.RapidPay.DTO
{
    public class GetPaymentDTO
    {
        public static explicit operator GetPaymentDTO(RapidPay.Entities.Payment v)
        {
            if (v == null)
                return null;

            return new GetPaymentDTO()
            {

            };
        }
    }
}