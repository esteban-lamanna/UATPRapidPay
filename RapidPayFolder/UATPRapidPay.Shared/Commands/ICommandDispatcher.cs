using System.Threading.Tasks;
using UATPRapidPay.Shared;

namespace UATPRapidPay.Shared.Commands
{
    public interface ICommandDispatcher
    {
        public Task SendAsync<T>(T command) where T : class, ICommand;
    }
}