using InazumaAPI.Application.CommandBuss;
using InazumaAPI.Application.Filter;
using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Application.Querys;
using InazumaAPI.Domain.Aggregates.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Commands
{
    public class DeletePlayerCommandHandler : ICommandHandler<DeletePlayerCommand>
    {
        private readonly IPlayerModelRepository _playerModelRepository;

        public DeletePlayerCommandHandler(IPlayerModelRepository playerModelRepository)
        {
            _playerModelRepository = playerModelRepository;
        }

        public async Task HandleAsync(DeletePlayerCommand command)
        {

            PlayerValidation.DeleteIdFilter(command.NombreId);
            PlayerValidation.SqlInyectionFilter(command.NombreId);

            bool deleted = await _playerModelRepository.DeleteAsync(command.NombreId);

            if (!deleted)
            {
                throw new InvalidOperationException("El jugador no existe");
            }

        }

    }
}
