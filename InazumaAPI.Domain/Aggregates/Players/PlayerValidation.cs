using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InazumaAPI.Domain.Aggregates.Players
{
    public static class PlayerValidation
    {
        public static void LenghtFilter(PlayerModel player)
        {
            if (player.Imagen.Length > 10485760)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.NombreId.Length > 50)
            {
                throw new ArgumentException("Mal Construido");
            }
        }

        public static void IntegerFilter(PlayerModel player)
        {
            if (player.Inteligencia > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.PT > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Tecnica > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Agilidad > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Control > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Fisico > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.PE > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Patada > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Presion > 255 || player.Inteligencia < 20)
            {
                throw new ArgumentException("Mal Construido");
            }
        }

        public static void NullFilter(PlayerModel player)
        {
            if (player.Imagen == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.NombreId == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Inteligencia == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.PT == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Patada == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Control == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Tecnica == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Inteligencia == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Presion == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Fisico == null)
            {
                throw new ArgumentException("Mal Construido");
            }
            if (player.Agilidad == null)
            {
                throw new ArgumentException("Mal Construido");
            }
        }

        public static void DeleteIdFilter(string id)
        {
            if(id == null)
            {
                throw new ArgumentException("Mal Construido");
            }
        }


        public static void SqlInyectionFilter(String s)
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
                if (Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("Mal Construido: posible inyección SQL detectada.");
                }
            }
        }
    }
}
