using Microsoft.AspNetCore.Mvc;
using System;
using UATPRapidPay.Card.Application.Commands;

namespace UATPRapidPay.Card.Api.Models.Purchase
{
    internal class CreatePurchaseRequest
    {
        public string CardNumber { get; set; }

        public decimal Price { get; set; }
        
        public Guid PurchaseId { get; set; }

        public string ProductName { get; set; }
    }

    internal static class CreatePurchaseRequestExtensions
    {
        internal static CreatePurchaseCommand ToCommand(this CreatePurchaseRequest request)
        {
            return new CreatePurchaseCommand()
            {
                Price = request.Price,
                CardNumber = request.CardNumber,
                PurchaseId = request.PurchaseId,
                ProductName = request.ProductName
            };
        }
    }
}