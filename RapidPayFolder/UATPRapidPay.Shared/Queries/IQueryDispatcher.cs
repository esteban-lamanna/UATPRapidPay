using System.Threading.Tasks;

namespace UATPRapidPay.Shared.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}