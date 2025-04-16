using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = InazumaAPI.Application.CommandBuss.ICommand;

namespace InazumaAPI.Application.Commands
{
    public class PutPlayerCommand : ICommand
    {
        public PutPlayerCommand(string nombreId, int? pe, int? pt, int? patada, int? control,
            int? tecnica, int? inteligencia, int? presion, int? fisico, int? agilidad, string? imagen)
        {
            this.NombreId = nombreId;
            this.PE = pe;
            this.PT = pt;
            this.Patada = patada;
            this.Control = control;
            this.Tecnica = tecnica;
            this.Inteligencia = inteligencia;
            this.Presion = presion;
            this.Fisico = fisico;
            this.Agilidad = agilidad;
            this.Imagen = imagen;
        }

        public string NombreId { get; set; }
        public int? PE { get; set; }
        public int? PT { get; set; }
        public int? Patada { get; set; }
        public int? Control { get; set; }
        public int? Tecnica { get; set; }
        public int? Inteligencia { get; set; }
        public int? Presion { get; set; }
        public int? Fisico { get; set; }
        public int? Agilidad { get; set; }
        public string? Imagen { get; set; }
    }
}
