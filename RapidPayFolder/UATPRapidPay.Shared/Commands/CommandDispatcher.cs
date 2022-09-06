using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace UATPRapidPay.Shared.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IServiceScopeFactory _serviceScopeFactory;

        public CommandDispatcher(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task SendAsync<T>(T command) where T : class, ICommand
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<T>>();

            await handler.HandleAsync(command);
        }
    }
}