using InazumaAPI.Application.QueryBuss;
using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Reads.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Querys
{
    public class GetAllPlayersQueryHandler : IQueryHandler<GetAllPlayersQuery, IEnumerable<PlayerModel>>
    {
        private readonly IPlayerQueryRepository _playerQueryRepository;

        public GetAllPlayersQueryHandler(IPlayerQueryRepository playerQueryRepository)
        {
            _playerQueryRepository = playerQueryRepository;
        }

        public async Task<IEnumerable<PlayerModel>> HandleAsync(GetAllPlayersQuery query)
        {
            IEnumerable<PlayerModel> PlayerList = await _playerQueryRepository.GetAllByStatAsync(query.Stat);

            if (PlayerList == null)
            {

            }
            return PlayerList;
        }
    }
}

