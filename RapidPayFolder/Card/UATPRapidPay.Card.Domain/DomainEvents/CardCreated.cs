using System;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared;

namespace UATPRapidPay.Card.Domain.DomainEvents
{
    public class CardCreated : IDomainEvent
    {
        public CardCreated(Guid cardId, Limit limit, Guid personId)
        {
            CardId = cardId;
            Limit = limit;
            PersonId = personId;
        }

        public Guid CardId { get; private set; }
        public Limit Limit { get; private set; }
        public Guid PersonId { get; private set; }
    }
}