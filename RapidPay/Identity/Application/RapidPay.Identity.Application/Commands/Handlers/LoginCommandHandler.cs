using UATPRapidPay.Shared.Commands;

namespace RapidPay.Identity.Application.Commands.Handlers
{
    internal class LoginCommandHandler : ICommandHandler<LoginCommand>, ICommand
    {
        public Task HandleAsync(LoginCommand command)
        {
            throw new NotImplementedException();
        }
    }
}