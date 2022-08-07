using System;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands
{
    public class CreateCardCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public decimal Limit { get; set; }
    }
}