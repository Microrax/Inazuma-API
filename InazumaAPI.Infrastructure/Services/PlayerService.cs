using InazumaAPI.Domain.Aggregates.Players;
using InazumaAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace InazumaAPI.Infrastructure.Services
{
    public class PlayerService
    {
        private readonly InazumaDbContext _inazumaDbContext;

        public PlayerService(InazumaDbContext InazumaDbContext)
        {
            _inazumaDbContext = InazumaDbContext;
        }


        public async Task AddPlayerAsync(PlayerModel player)
        {
            try
            {
                await _inazumaDbContext.Players.AddAsync(player);

                await _inazumaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar jugador:"+ ex.Message);
            }
        }

        public async Task<bool> UpdatePlayerAsync(PlayerModel playerModel)
        {
            try
            {
                var player = await _inazumaDbContext.Players.FirstOrDefaultAsync(p => p.NombreId == playerModel.NombreId);

                if (player == null)
                {
                    return false;
                }
                
                player.PE = playerModel.PE.HasValue ? playerModel.PE.Value : player.PE;
                player.PT = playerModel.PT.HasValue ? playerModel.PT.Value : player.PT;
                player.Patada = playerModel.Patada.HasValue ? playerModel.Patada.Value : player.Patada;
                player.Control = playerModel.Control.HasValue ? playerModel.Control.Value : player.Control;
                player.Tecnica = playerModel.Tecnica.HasValue ? playerModel.Tecnica.Value : player.Tecnica;
                player.Inteligencia = playerModel.Inteligencia.HasValue ? playerModel.Inteligencia.Value : player.Inteligencia;
                player.Presion = playerModel.Presion.HasValue ? playerModel.Presion.Value : player.Presion;
                player.Fisico = playerModel.Fisico.HasValue ? playerModel.Fisico.Value : player.Fisico;
                player.Agilidad = playerModel.Agilidad.HasValue ? playerModel.Agilidad.Value : player.Agilidad;
                player.Imagen = playerModel.Imagen ?? player.Imagen;

                await _inazumaDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar jugador: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeletePlayerAsync(string nombreId)
        {
            try
            {
                var player = await _inazumaDbContext.Players.FirstOrDefaultAsync(p => p.NombreId == nombreId);

                if (player == null)
                {
                    return false;
                }

                _inazumaDbContext.Players.Remove(player);

                await _inazumaDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar jugador: " + ex.Message);
                return false;
            }
        }
    }
}
