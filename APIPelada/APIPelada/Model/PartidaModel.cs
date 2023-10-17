﻿namespace APIPelada.Model
{
    public class PartidaModel
    {
        // public int IdPartida { get; set; }
        public string PlacarTimeCasa { get; set; } = string.Empty;
        public string PlacarTimeFora { get; set; } = string.Empty; 
        public int TimeIdTimeFora { get; set; }
        public int TimeIdTimeCasa { get; set; }
        public string? TempoDePartida { get; set; }
        public bool? InicioPartida { get; set; }
        public bool Status { get; set; }
    }
}
