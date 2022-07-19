using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.LoginUser;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using RapidPay.EnterpriseBusinessRules.Entities.Repositories;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases
{
    public class LoginUserInteractor : ILoginUserInputPort
    {
        private readonly IUserLoginRepository _loginUserRepository;
        private readonly ILoginUserOutputPort _loginUserOutputPort;

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