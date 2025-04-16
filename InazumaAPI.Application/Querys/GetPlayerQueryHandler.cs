using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Reads.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

using System.Threading.Tasks;

namespace InazumaAPI.Application.Querys
{
    public class GetPlayerQueryHandler : IQueryHandler<GetPlayerQuery, PlayerModel>
    {
        private readonly IPlayerQueryRepository _playerQueryRepository;
        public GetPlayerQueryHandler(IPlayerQueryRepository playerQueryRepository) 
        { 
            this._playerQueryRepository = playerQueryRepository;
        }

        public async Task<PlayerModel> HandleAsync(GetPlayerQuery query)
        {
            PlayerModel player = await _playerQueryRepository.GetByNombreIdAsync(query.NombreId);

            if (player == null)
            {
                throw new InvalidOperationException("El jugador no existe");
            }
            return player;
        }
    }
}
