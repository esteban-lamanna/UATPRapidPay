﻿using System.Threading.Tasks;

namespace UATPRapidPay.Shared.Commands
{
    public interface ICommandHandler<T>
        where T : class, ICommand
    {
        Task HandleAsync(T command);
    }
}