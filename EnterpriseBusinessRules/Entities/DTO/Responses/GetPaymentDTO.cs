namespace RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses
{
    public class GetPaymentDTO
    {
        public static explicit operator GetPaymentDTO(Payment v)
        {
            if (v == null)
                return null;

            return new GetPaymentDTO()
            {

            };
        }
    }
}