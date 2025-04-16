using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Infrastructure.Services
{
    public class PlayerQueryService
    {
        private readonly InazumaDbContext _InazumaDbContext;

        public PlayerQueryService(InazumaDbContext InazumaDbContext)
        {
            _InazumaDbContext = InazumaDbContext;
        }

        public async Task<PlayerModel?> GetPlayerByNombreIdAsync(string nombreId)
        {
            try
            {
                var player = await _InazumaDbContext.Players.FirstOrDefaultAsync(p => p.NombreId == nombreId);

                if (player == null)
                {
                    Console.WriteLine($"Jugador con NombreId {nombreId} no encontrado.");
                }

                return player;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el jugador: " + ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<PlayerModel>> GetPlayersOrderedByTiroAsync(string stat)
        {

            
            try
            {
                var players = new List<PlayerModel>();

                switch (stat)
                {
                    case "PE":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.PE)
                    .ToListAsync();
                        break;
                    case "PT":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.PT)
                    .ToListAsync();
                        break;
                    case "Patada":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Patada)
                    .ToListAsync();
                        break;
                    case "Control":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Control)
                    .ToListAsync();
                        break;
                    case "Tecnica":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Tecnica)
                    .ToListAsync();
                        break;
                    case "Inteligencia":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Inteligencia)
                    .ToListAsync();
                        break;
                    case "Presion":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Presion)
                    .ToListAsync();
                        break;
                    case "Fisico":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Fisico)
                    .ToListAsync();
                        break;
                    case "Agilidad":
                        players = await _InazumaDbContext.Players
                    .OrderByDescending(p => p.Agilidad)
                    .ToListAsync();
                        break;
                }
                return players;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los jugadores ordenados por " + stat + ": " + ex.Message);
                return new List<PlayerModel>(); 
            }
        }
    }
}
