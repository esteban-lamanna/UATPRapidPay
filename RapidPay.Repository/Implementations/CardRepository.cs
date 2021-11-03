namespace Persistence.RapidPay.Repository
{
    public class CardRepository : ICardRepository
    {
        readonly RapidPayContext _rapidPayContext;

        public CardRepository(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }
    }
}