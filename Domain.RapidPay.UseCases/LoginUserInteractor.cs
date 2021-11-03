using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using Drivers.RapidPay.Repository;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCases
{
    public class LoginUserInteractor : ILoginUserInputPort
    {
        readonly IUserLoginRepository _loginUserRepository;
        readonly ILoginUserOutputPort _loginUserOutputPort;

        public LoginUserInteractor(IUserLoginRepository loginUserRepository,
                                   ILoginUserOutputPort loginUserOutputPort)
        {
            _loginUserRepository = loginUserRepository;
            _loginUserOutputPort = loginUserOutputPort;
        }

        public async Task HandleAsync(LoginUserDTO loginUserDTO)
        {
            var user = await _loginUserRepository.Authenticate(loginUserDTO);

            var userResponse = new UserDTO()
            {
                Id = user.Id
            };

            await _loginUserOutputPort.HandleAsync(userResponse);
        }
    }
}