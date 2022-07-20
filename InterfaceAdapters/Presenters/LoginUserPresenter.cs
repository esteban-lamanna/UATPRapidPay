using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.LoginUser;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System.Threading.Tasks;

namespace RapidPay.InterfaceAdapters.Presenters
{
    public class LoginUserPresenter : ILoginUserOutputPort, IPresenter<UserDTO>
    {
        public UserDTO Content { get; private set; }

        public Task HandleAsync(UserDTO userDTO)
        {
            Content = userDTO;

            return Task.CompletedTask;
        }
    }
}