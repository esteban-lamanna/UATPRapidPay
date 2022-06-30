using System;
using System.Threading.Tasks;

namespace UATPRapidPay.Card.Domain.Repositories
{
    internal interface IPersonRepository
    {
        Task<Entities.Person> GetByIdAsync(Guid id);
        Task CreateAsync(Entities.Person person);
    }
}