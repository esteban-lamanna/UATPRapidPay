using System;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands
{
    public class CreatePurchaseCommand : ICommand
    {
        public Guid PurchaseId { get; set; }
        public string CardNumber { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}