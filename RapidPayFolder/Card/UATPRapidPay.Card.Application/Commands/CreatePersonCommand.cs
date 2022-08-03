using System;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands
{
    public class CreatePersonCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}