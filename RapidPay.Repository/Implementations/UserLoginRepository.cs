using Domain.RapidPay.DTO;
using Domain.RapidPay.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Drivers.RapidPay.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        readonly RapidPayContext _rapidPayContext;

        public UserLoginRepository(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }

        public async Task<User> Authenticate(LoginUserDTO loginUserDTO)
        {
            return await _rapidPayContext.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Email == loginUserDTO.Username &&
                                                                               a.Password == loginUserDTO.Password);
        }
    }
}