using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

        public PaymentLogic(RapidPayContext rapidPayContext,
                            IFeeLogic feeLogic,
                            IServiceProvider serviceProvider)
        {
            _rapidPayContext = rapidPayContext;
            _feeLogic = feeLogic;
            _serviceProvider = serviceProvider;
        }

        public void PayMultithreadingAsync(int idUser, string cardNumber, decimal amount)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                lock (lockPaymentMultithreading)
                {
                    var context = scope.ServiceProvider.GetRequiredService<RapidPayContext>();

                    var card = context.Set<Card>().First(a => a.Number == cardNumber && a.IdUser == idUser);

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

                    context.SaveChanges();
                }
            }
        }

        public async Task PayAsync(int idUser, string cardNumber, decimal amount)
        {
            var card = await GetCardAsync(idUser, cardNumber);

            lock (lockPayment)
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

                _rapidPayContext.Attach(payment);

                _rapidPayContext.SaveChanges();
            }
        }

        private async Task<Card> GetCardAsync(int idUser, string cardNumber)
        {
            return await _rapidPayContext.Set<Card>().FirstAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }
    }
}