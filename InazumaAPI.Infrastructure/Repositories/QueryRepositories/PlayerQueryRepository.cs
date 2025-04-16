using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Infrastructure.Services;
using InazumaAPI.Reads.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Infrastructure.Repositories.QueryRepositories
{
    public class PlayerQueryRepository : IPlayerQueryRepository
    {
        private readonly MySQLConfiguration _connectionString;
        private readonly PlayerQueryService _playerQueryService;

        public PlayerQueryRepository(MySQLConfiguration connectionString, PlayerQueryService playerQueryService)
        {
            _connectionString = connectionString;
            _playerQueryService = playerQueryService;
        }


        public async Task<IEnumerable<PlayerModel?>> GetAllByStatAsync(string Stat)
        {
            return await _playerQueryService.GetPlayersOrderedByTiroAsync(Stat);
        }

        public async Task<PlayerModel?> GetByNombreIdAsync(string NombreId)
        {
            return await _playerQueryService.GetPlayerByNombreIdAsync(NombreId);
        }
    }
}
