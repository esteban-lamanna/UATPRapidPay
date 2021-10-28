using Microsoft.EntityFrameworkCore;
using RapidPay.Logic.Entities;
using RapidPay.Repository;
using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public class UserLoginLogic : IUserLoginLogic
    {
        readonly RapidPayContext _rapidPayContext;

        public UserLoginLogic(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }

        public async Task<bool> Authenticate(string authUsername, string password)
        {
            return await _rapidPayContext.Set<User>()
                                   .AnyAsync(a => a.Email == authUsername && a.Password == password);
        }
    }
}