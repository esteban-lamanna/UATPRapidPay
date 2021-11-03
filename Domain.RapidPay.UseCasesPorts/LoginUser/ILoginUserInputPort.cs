using Domain.RapidPay.DTO;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCasesPorts
{
    public interface ILoginUserInputPort
    {
        Task HandleAsync(LoginUserDTO loginUserDTO);
    }
}