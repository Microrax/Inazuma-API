using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommand = InazumaAPI.Application.CommandBuss.ICommand;

namespace InazumaAPI.Application.Commands
{
    public class DeletePlayerCommand : ICommand
    {
        public DeletePlayerCommand(string nombreId)
        {
            this.NombreId = nombreId;
        }

        public String NombreId { get; set; }
    }
}
