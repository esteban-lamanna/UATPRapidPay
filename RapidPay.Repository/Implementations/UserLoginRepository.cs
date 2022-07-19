using Microsoft.EntityFrameworkCore;
using RapidPay.EnterpriseBusinessRules.Entities;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using RapidPay.EnterpriseBusinessRules.Entities.Repositories;
using System.Threading.Tasks;

namespace RapidPay.InterfaceAdapters.Gateways.Repository.EF.Implementations
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly RapidPayContext _rapidPayContext;

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