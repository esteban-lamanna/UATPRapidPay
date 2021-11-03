using Domain.RapidPay.DTO;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCasesPorts
{
    public interface ILoginUserOutputPort
    {
        Task HandleAsync(UserDTO userDTO);
    }
}