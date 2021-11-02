namespace Persistence.RapidPay.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly RapidPayContext _rapidPayContext;

        public PaymentRepository(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }


    }
}