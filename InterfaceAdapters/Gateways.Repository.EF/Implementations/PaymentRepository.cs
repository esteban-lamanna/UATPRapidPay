using RapidPay.EnterpriseBusinessRules.Entities.Repositories;

namespace RapidPay.InterfaceAdapters.Gateways.Repository.EF.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly RapidPayContext _rapidPayContext;

        public PaymentRepository(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }
    }
}