using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public class CardNumberFactory : ICardNumberFactory
    {
        public async Task<CardNumber> Generate(Person person)
        {
            return new CardNumber("1231231231232");
        }
    }
}