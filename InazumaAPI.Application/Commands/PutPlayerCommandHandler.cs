using InazumaAPI.Application.CommandBuss;
using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Reads.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Commands
{
    public class PutPlayerCommandHandler : ICommandHandler<PutPlayerCommand>
    {
        private readonly IPlayerModelRepository _playerModelRepository;


        public PutPlayerCommandHandler(IPlayerModelRepository playerModelRepository)
        {
            _playerModelRepository = playerModelRepository;
        }

        public async Task HandleAsync(PutPlayerCommand command)
        {
            var player = new PlayerModel(command.NombreId, command.PE, command.PT, command.Patada, command.Control,
                command.Tecnica, command.Inteligencia, command.Presion, command.Fisico, command.Agilidad, command.Imagen);

            PlayerValidation.IntegerFilter(player);
            PlayerValidation.LenghtFilter(player);
            PlayerValidation.SqlInyectionFilter(player.Imagen);
            PlayerValidation.SqlInyectionFilter(player.NombreId);

            bool created = await _playerModelRepository.UpdateAsync(player);

            if (!created) 
            {
                throw new InvalidOperationException("El jugador no existe");
            }
        }
    }
}
