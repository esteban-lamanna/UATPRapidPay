using Domain.RapidPay.Entities;
using System.Threading.Tasks;

namespace Domain.RapidPay.Logic
{
    public class UserLoginLogic : IUserLoginLogic
    {
        readonly IUnitOfWork _rapidPayContext;

        public UserLoginLogic(IUnitOfWork rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }

        public async Task<User> Authenticate(string authUsername, string password)
        {
            return new User();// await _rapidPayContext.Set<User>().FirstOrDefaultAsync(a => a.Email == authUsername && a.Password == password);
        }
    }
}