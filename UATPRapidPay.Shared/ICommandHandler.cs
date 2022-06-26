using System.Threading.Tasks;

namespace UATPRapidPay.Shared
{
    public interface ICommandHandler<T>
        where T : class
    {
        Task HandleAsync<T>(T command) where T : class;
    }
}