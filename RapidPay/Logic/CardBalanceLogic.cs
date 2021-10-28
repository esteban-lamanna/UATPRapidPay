using Microsoft.EntityFrameworkCore;
using RapidPay.Logic.Entities;
using RapidPay.Logic.Exceptions;
using RapidPay.Models;
using RapidPay.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public class CardBalanceLogic : ICardBalanceLogic
    {
        readonly RapidPayContext _rapidPayContext;
        readonly IFeeLogic _feeLogic;

        public CardBalanceLogic(RapidPayContext rapidPayContext, IFeeLogic feeLogic)
        {
            _rapidPayContext = rapidPayContext;
            _feeLogic = feeLogic;
        }

        public async Task CreateAsync(int idUser, string cardNumber, decimal limit)
        {
            if (await IsCardNumberInUseAsync(idUser, cardNumber))
                throw new CardNumberInUseException("Card number in use.");

            var card = new Card()
            {
                Limit = limit,
                IdUser = idUser,
                Number = cardNumber,
            };

            _rapidPayContext.Attach(card);

            await _rapidPayContext.SaveChangesAsync();
        }

        public async Task<GetBalanceResponse> GetBalanceAsync(int idUser,
                                                              string cardNumber,
                                                              DateTime from,
                                                              DateTime to)
        {
            await ValidateCardNumberAsync(idUser, cardNumber);

            var card = await GetCardAsync(idUser, cardNumber);

            var payments = _rapidPayContext.Set<Payment>()
                .Where(a => a.Date >= from)
                .Where(a => a.Date <= to)
                .Where(a => a.Card.Number == cardNumber)
                .OrderByDescending(a => a.Date)
                .AsNoTracking();

            return new GetBalanceResponse()
            {
                Limit = card.Limit,
                Payments = payments.Select(a => (PaymentResponse)a),
                Available = card.GetAvailable(payments)
            };
        }

        private async Task ValidateCardNumberAsync(int idUser, string cardNumber)
        {
            bool exists = await IsCardNumberInUseAsync(idUser, cardNumber);

            if (!exists)
                throw new InvalidCardException("Invalid card number.");
        }

        private async Task<bool> IsCardNumberInUseAsync(int idUser, string cardNumber)
        {
            return await _rapidPayContext.Set<Card>().AnyAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }

        public async Task PayAsync(int idUser, string cardNumber, decimal amount)
        {
            await ValidateCardNumberAsync(idUser, cardNumber);

            var card = await GetCardAsync(idUser, cardNumber);

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

            await _rapidPayContext.SaveChangesAsync();
        }

        private async Task<Card> GetCardAsync(int idUser, string cardNumber)
        {
            return await _rapidPayContext.Set<Card>().FirstAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }
    }
}