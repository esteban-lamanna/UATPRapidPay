using System.Threading.Tasks;
using UATPRapidPay.Shared;

namespace UATPRapidPay.Application.Commands.Handlers
{
    internal sealed class AddCardHandler : ICommandHandler<AddCardHandler>
    {
        public Task HandleAsync<T>(T command) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}