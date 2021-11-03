namespace Drivers.RapidPay.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly RapidPayContext _rapidPayContext;

        public UserRepository(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }
    }
}