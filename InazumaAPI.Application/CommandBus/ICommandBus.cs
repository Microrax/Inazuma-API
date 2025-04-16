using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.CommandBuss;

public interface ICommandBus
{
    Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
}
