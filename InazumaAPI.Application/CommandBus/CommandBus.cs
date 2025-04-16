﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.CommandBuss;

public sealed class CommandBus : ICommandBus
{
    private readonly IServiceProvider _serviceProvider;

    public CommandBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;

        if (handler is null)
        {
            throw new ArgumentNullException(nameof(handler));
        }

        await handler.HandleAsync(command);
    }
}
