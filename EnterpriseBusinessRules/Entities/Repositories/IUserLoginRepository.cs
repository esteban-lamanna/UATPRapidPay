using RapidPay.EnterpriseBusinessRules.Entities;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using System.Threading.Tasks;

namespace RapidPay.EnterpriseBusinessRules.Entities.Repositories
{
    public interface IUserLoginRepository
    {
        Task<User> Authenticate(LoginUserDTO loginUserDTO);
    }
}