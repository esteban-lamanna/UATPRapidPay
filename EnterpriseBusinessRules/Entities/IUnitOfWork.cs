using System.Threading.Tasks;

namespace RapidPay.EnterpriseBusinessRules.Entities
{
    public interface IUnitOfWork
    {
        public void StartTracking<T>(T objectToTrack);
        public Task SaveAsync();
    }
}