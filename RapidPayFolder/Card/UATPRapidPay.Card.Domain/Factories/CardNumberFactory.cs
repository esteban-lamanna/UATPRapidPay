using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public class CardNumberFactory : ICardNumberFactory
    {
        private readonly ICardRepository _cardRepository;
        private static readonly object _cardNumberLockObject = new();

        public CardNumberFactory(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardNumber> GenerateAsync(Person person)
        {
            lock (_cardNumberLockObject)
            {
                var lastNumber = _cardRepository.GetLastCardNumberAsync().GetAwaiter().GetResult();

                if (lastNumber == null)
                {
                    var firstCardNumber = 1.ToString("D16");
                    return new CardNumber(firstCardNumber);
                }

                var numberLong = long.Parse(lastNumber.Number) + 1;

                return new CardNumber(numberLong.ToString("D16"));
            }
        }
    }
}