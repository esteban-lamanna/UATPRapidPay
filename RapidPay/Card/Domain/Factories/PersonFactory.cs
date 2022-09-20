using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    internal class PersonFactory : IPersonFactory
    {
        public async Task<Person> GenerateAsync(Guid id, string personName, string personEmail)
        {
            return await Task.Run(() =>
            {
                return new Person(id, new Email(personEmail), new Name(personName));
            });
        }
    }
}