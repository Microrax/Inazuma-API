using FluentAssertions.Equivalency;
using InazumaAPI.Application.Commands;
using InazumaAPI.Domain.Aggregates.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InazumaAPI.Application.Filter
{
    public static class PlayerFilter
    {
        public static void LenghtFilter(AddPlayerCommand player)
        {
            if (player.Imagen.Length > 10485760 || player.Imagen == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if(player.NombreId.Length>50 || player.NombreId == null)
            {
                throw new ArgumentException("Mal Construido");
            }
        }

        public static void IntegerFilter(AddPlayerCommand player)
        {
            if(player.Inteligencia > 255 || player.Inteligencia<20 || player.Inteligencia == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if(player.PT > 255 || player.Inteligencia<20 || player.Inteligencia == null)
                {
                    throw new ArgumentException("Mal Construido");
                }
            if(player.Tecnica > 255 || player.Inteligencia<20 || player.Inteligencia == null)
                {
                    throw new ArgumentException("Mal Construido");
                }
            if(player.Agilidad > 255 || player.Inteligencia<20 || player.Inteligencia == null)
                {
                    throw new ArgumentException("Mal Construido");
                }
            if(player.Control > 255 || player.Inteligencia<20 || player.Inteligencia == null)
                {
                    throw new ArgumentException("Mal Construido");
                }
            if(player.Fisico > 255 || player.Inteligencia<20 || player.Inteligencia == null)
                {
                    throw new ArgumentException("Mal Construido");
                }
            if (player.PE > 255 || player.Inteligencia < 20 || player.Inteligencia == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Patada > 255 || player.Inteligencia < 20 || player.Inteligencia == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Presion > 255 || player.Inteligencia < 20 || player.Inteligencia == null)
            {
                throw new ArgumentException("Mal Construido");
            }
        }

        public static string SqlInyectionFilter(string input)
        {

            string[] blacklistPatterns = new string[]
            {
            @"--",
            @"\b(OR|AND)\b",
            @"['"";]",
            @"\b(DROP|SELECT|INSERT|DELETE|UPDATE|UNION|EXEC|XP_)\b",
            @"[*=#]",
            };

            foreach (var pattern in blacklistPatterns)
            {
                if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("Mal Construido: posible inyección SQL detectada.");
                }
            }

            return input;
        }
    }
}
