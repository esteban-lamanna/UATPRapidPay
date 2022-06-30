using System.Threading.Tasks;

namespace UATPRapidPay.Card.Application.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}