using System.Threading.Tasks;

namespace Domain.RapidPay.Entities
{
    public interface IUnitOfWork
    {
        public void StartTracking<T>(T objectToTrack);
        public Task SaveAsync();
    }
}