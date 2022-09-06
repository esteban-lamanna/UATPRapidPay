using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;

namespace UATPRapidPay.Card.Domain.Factories
{
    public interface IPersonFactory
    {
        Task<Person> GenerateAsync(Guid id, string personName, string personEmail);
    }
}