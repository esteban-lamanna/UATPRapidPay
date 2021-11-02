using Domain.RapidPay.Entities;
using Domain.RapidPay.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Domain.RapidPay.Logic
{
    public class PaymentLogic : IPaymentLogic
    {
        readonly IUnitOfWork _rapidPayContext;
        readonly IFeeLogic _feeLogic;
        static readonly object lockPayment = new object();
        static readonly object lockPaymentMultithreading = new object();
        readonly IServiceProvider _serviceProvider;
        readonly ILogger<PaymentLogic> _logger;

        public PaymentLogic(IUnitOfWork rapidPayContext,
                            IFeeLogic feeLogic,
                            IServiceProvider serviceProvider,
                            ILogger<PaymentLogic> logger)
        {
            _rapidPayContext = rapidPayContext;
            _feeLogic = feeLogic;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public void PayMultithreading(int idUser, string cardNumber, decimal amount)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                lock (lockPaymentMultithreading)
                {
                    var context = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var card = new Card();// context.Set<Card>().First(a => a.Number == cardNumber && a.IdUser == idUser);

                    Pay(idUser, amount, context, card);
                }
            }
        }

        private void Pay(int idUser, decimal amount, IUnitOfWork context, Card card)
        {
            card.ValidateLimit(amount);

            var payment = new Payment()
            {
                Amount = amount,
                Card = card,
                IdUser = idUser,
                Date = DateTime.UtcNow,
                Fee = _feeLogic.GetFee()
            };

            context.StartTracking(payment);

            card.Available -= payment.Amount + payment.Fee;

            try
            {
                context.SaveAsync();
            }
            catch (ConcurrencyException e)
            {
                _logger.LogWarning(e, $"concurrency exception");
                throw;
            }
        }

        public async Task PayAsync(int idUser, string cardNumber, decimal amount)
        {
            var card = await GetCardAsync(idUser, cardNumber);

            lock (lockPayment)
            {
                Pay(idUser, amount, _rapidPayContext, card);
            }
        }

        private async Task<Card> GetCardAsync(int idUser, string cardNumber)
        {
            return new Card();// await _rapidPayContext.Set<Card>().FirstAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }
    }
}