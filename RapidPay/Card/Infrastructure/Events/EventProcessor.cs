using System.Collections.Generic;
using System.Threading.Tasks;
using UATPRapidPay.Shared;
using UATPRapidPay.Shared.Services;

namespace UATPRapidPay.Card.Infrastructure.Events
{
    internal class EventProcessor : IEventProcessor
    {
        public Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            return Task.CompletedTask;
        }
    }
}