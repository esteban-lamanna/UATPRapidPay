using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.LoginUser
{
    public interface ILoginUserInputPort
    {
        Task HandleAsync(LoginUserDTO loginUserDTO);
    }
}