using System;
using UATPRapidPay.Card.Application.Commands;

namespace UATPRapidPay.Card.Api.Models.Card
{
    public class CreateCardRequest
    {
        public Guid PersonId { get; set; }
        public Guid CardId { get; set; }
        public decimal Limit { get; set; }
    }

    internal static class CreateCardRequestExtensions
    {
        internal static CreateCardCommand ToCommand(this CreateCardRequest request)
        {
            return new CreateCardCommand()
            {
                Limit = request.Limit,
                PersonId = request.PersonId
            };
        }
    }
}