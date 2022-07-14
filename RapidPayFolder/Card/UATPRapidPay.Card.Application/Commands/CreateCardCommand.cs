using System;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands
{
    public class CreateCardCommand : ICommand
    {
        public Guid Id { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
    }
}