using InazumaAPI.Application.CommandBuss;
using InazumaAPI.Application.Filter;
using InazumaAPI.Application.Querys;
using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Reads.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Commands
{
    public class AddPlayerCommandHandler : ICommandHandler<AddPlayerCommand>
    {
        private readonly IPlayerModelRepository _playerModelRepository;
        private readonly IPlayerQueryRepository _playerQueryRepository;


        public AddPlayerCommandHandler(IPlayerModelRepository playerModelRepository, 
            IPlayerQueryRepository playerQueryRepository)
        {
            _playerModelRepository = playerModelRepository;
            _playerQueryRepository = playerQueryRepository;
        }

        public async Task HandleAsync(AddPlayerCommand command)
        {
            var player = new PlayerModel(command.NombreId, command.PE, command.PT, command.Patada, command.Control, command.Tecnica, command.Inteligencia,
                command.Presion, command.Fisico, command.Agilidad, command.Imagen);

            PlayerValidation.IntegerFilter(player);
            PlayerValidation.LenghtFilter(player);
            PlayerValidation.NullFilter(player);
            PlayerValidation.SqlInyectionFilter(player.Imagen);
            PlayerValidation.SqlInyectionFilter(player.NombreId);

            var playerQuery = await _playerQueryRepository.GetByNombreIdAsync(command.NombreId);

            if (playerQuery != null){
                throw new InvalidOperationException("Ya existe el jugador");
            }

            await _playerModelRepository.AddAsync(player);
        }
    }
}
