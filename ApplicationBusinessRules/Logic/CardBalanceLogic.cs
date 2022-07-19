using RapidPay.EnterpriseBusinessRules.Entities;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using RapidPay.EnterpriseBusinessRules.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.Logic
{
    public class CardBalanceLogic : ICardBalanceLogic
    {
        private readonly IUnitOfWork _rapidPayContext;
        private readonly IFeeLogic _feeLogic;

        public CardBalanceLogic(IUnitOfWork rapidPayContext, IFeeLogic feeLogic)
        {
            _rapidPayContext = rapidPayContext;
            _feeLogic = feeLogic;
        }

        public async Task CreateAsync(int idUser, string cardNumber, decimal limit)
        {
            if (await IsCardNumberInUseAsync(idUser, cardNumber))
                throw new CardNumberInUseException("Card number in use.");

            Card card = new Card()
            {
                Limit = limit,
                Available = limit,
                IdUser = idUser,
                Number = cardNumber,
            };

            _rapidPayContext.StartTracking(card);

            await _rapidPayContext.SaveAsync();
        }

        public async Task<GetBalanceDTO> GetBalanceAsync(int idUser,
                                                              string cardNumber,
                                                              DateTime from,
                                                              DateTime to)
        {
            await ValidateCardNumberAsync(idUser, cardNumber);

            Card card = await GetCardAsync(idUser, cardNumber);

            List<Payment> payments = new List<Payment>();
            /*_rapidPayContext.Set<Payment>()
                .Where(a => a.Date >= from)
                .Where(a => a.Date <= to)
                .Where(a => a.Card.Number == cardNumber)
                .OrderByDescending(a => a.Date)
                .AsNoTracking();*/

            return new GetBalanceDTO()
            {
                Limit = card.Limit,
                Payments = payments.Select(a => (GetPaymentDTO)a),
                Available = card.Available
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
            return false;// await _rapidPayContext.Set<Card>().AnyAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }

        private async Task<Card> GetCardAsync(int idUser, string cardNumber)
        {
            return new Card();//await _rapidPayContext.Set<Card>().FirstAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }
    }
}