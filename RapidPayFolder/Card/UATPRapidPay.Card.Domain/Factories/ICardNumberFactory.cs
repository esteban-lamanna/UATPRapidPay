using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public interface ICardNumberFactory
    {
        Task<CardNumber> GenerateAsync(Person person);
    }
}