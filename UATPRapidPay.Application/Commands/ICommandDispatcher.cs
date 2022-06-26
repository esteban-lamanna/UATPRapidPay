using System.Threading.Tasks;

namespace UATPRapidPay.Application.Commands
{
    public interface ICommandDispatcher
    {
        public Task SendAsync<T>(T command) where T : class;
    }
}