using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.LoginUser
{
    public interface ILoginUserOutputPort
    {
        Task HandleAsync(UserDTO userDTO);
    }
}