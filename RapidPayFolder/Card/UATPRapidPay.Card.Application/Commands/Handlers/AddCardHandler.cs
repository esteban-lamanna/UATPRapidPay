﻿using System.Threading.Tasks;
using UATPRapidPay.Shared;

namespace UATPRapidPay.Card.Application.Commands.Handlers
{
    internal sealed class AddCardHandler : ICommandHandler<AddCardHandler>, ICommand
    {
        public Task HandleAsync(AddCardHandler command)
        {
            throw new System.NotImplementedException();
        }
    }
}