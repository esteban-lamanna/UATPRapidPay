using Domain.RapidPay.Entities;
using System.Threading.Tasks;

namespace Drivers.RapidPay.Repository
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