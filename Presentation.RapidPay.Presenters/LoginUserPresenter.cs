using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using System.Threading.Tasks;

namespace InterfaceAdapters.RapidPay.Presenters
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