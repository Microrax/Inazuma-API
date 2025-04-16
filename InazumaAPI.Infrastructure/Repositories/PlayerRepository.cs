using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Infrastructure.DbContexts;
using InazumaAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerModelRepository
    {

        private readonly MySQLConfiguration _connectionString;
        private readonly PlayerService _playerService;

        public PlayerRepository(MySQLConfiguration connectionString, PlayerService playerService)
        {
            _connectionString = connectionString;
            _playerService = playerService;
        }


        public async Task AddAsync(PlayerModel player)
        {
            await _playerService.AddPlayerAsync(player);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _playerService.DeletePlayerAsync(id);
        }

        public async Task<bool> UpdateAsync(PlayerModel player)
        {
            return await _playerService.UpdatePlayerAsync(player);
        }
    }
}
