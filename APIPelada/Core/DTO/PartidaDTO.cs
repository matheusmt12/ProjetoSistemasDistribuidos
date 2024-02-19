using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PartidaDTO
    {
        public string PlacarTimeCasa { get; set; } = string.Empty;
        public string PlacarTimeFora { get; set; } = string.Empty;
        public string NomeTimeFora { get; set; }
        public string NomeTimeCasa { get; set; }
        public string? TempoDePartida { get; set; }
        public bool? InicioPartida { get; set; }
        public bool Status { get; set; }
    }
}
