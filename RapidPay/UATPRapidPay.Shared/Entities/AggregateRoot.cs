using System.Collections.Generic;

namespace UATPRapidPay.Shared.Entities
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }

        private bool _versionIncremented;

        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> Events { get { return _events; } }

        public void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
            IncrementVersion();
        }

        protected void IncrementVersion()
        {
            if (_versionIncremented)
                return;

            _versionIncremented = true;
            Version++;
        }
    }
}