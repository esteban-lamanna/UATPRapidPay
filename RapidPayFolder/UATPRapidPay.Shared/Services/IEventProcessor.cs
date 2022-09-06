using System.Collections.Generic;
using System.Threading.Tasks;

namespace UATPRapidPay.Shared.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}