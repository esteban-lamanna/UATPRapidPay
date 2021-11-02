using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RapidPay.Logic.Entities;
using RapidPay.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public class PaymentLogic : IPaymentLogic
    {
        readonly RapidPayContext _rapidPayContext;
        readonly IFeeLogic _feeLogic;
        static readonly object lockPayment = new object();
        static readonly object lockPaymentMultithreading = new object();
        readonly IServiceProvider _serviceProvider;
        readonly ILogger<PaymentLogic> _logger;

        public PaymentLogic(RapidPayContext rapidPayContext,
                            IFeeLogic feeLogic,
                            IServiceProvider serviceProvider, ILogger<PaymentLogic> logger)
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
                    var context = scope.ServiceProvider.GetRequiredService<RapidPayContext>();

                    var card = context.Set<Card>().First(a => a.Number == cardNumber && a.IdUser == idUser);

                    Pay(idUser, amount, context, card);
                }
            }
        }

        private void Pay(int idUser, decimal amount, RapidPayContext context, Card card)
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

            context.Attach(payment);

            card.Available -= payment.Amount + payment.Fee;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
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
            return await _rapidPayContext.Set<Card>().FirstAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }
    }
}