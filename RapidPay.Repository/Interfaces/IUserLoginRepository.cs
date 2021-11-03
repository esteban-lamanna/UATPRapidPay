using Domain.RapidPay.DTO;
using Domain.RapidPay.Entities;
using System.Threading.Tasks;

namespace Drivers.RapidPay.Repository
{
    public interface IUserLoginRepository
    {
        Task<User> Authenticate(LoginUserDTO loginUserDTO);
    }
}