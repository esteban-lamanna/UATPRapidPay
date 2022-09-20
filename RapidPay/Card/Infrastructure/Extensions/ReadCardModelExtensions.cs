using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Infrastructure.Models;

namespace UATPRapidPay.Card.Infrastructure.Extensions
{
    internal static class ReadCardModelExtensions
    {
        internal static GetCardDTO AsDto(this ReadCardModel model)
        {
            if (model == null)
                return null;

            return new GetCardDTO()
            {
                CardNumber = model.Number,
                Limit = model.Limit,
                ExpirationDate = model.ExpirationDate
            };
        }
    }
}