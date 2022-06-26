using System.Threading.Tasks;

namespace UATPRapidPay.Shared
{
    public interface ICommandHandler<T>
        where T : class
    {
        Task HandleAsync(T command);
    }
}