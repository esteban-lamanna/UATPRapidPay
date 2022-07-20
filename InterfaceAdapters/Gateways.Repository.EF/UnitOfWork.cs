using RapidPay.EnterpriseBusinessRules.Entities;
using System.Threading.Tasks;

namespace RapidPay.InterfaceAdapters.Gateways.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly RapidPayContext _rapidPayContext;

        public UnitOfWork(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }

        public async Task SaveAsync()
        {
            await _rapidPayContext.SaveChangesAsync();
        }

        public void StartTracking<T>(T objectToTrack)
        {
            _rapidPayContext.Attach(objectToTrack);
        }
    }
}