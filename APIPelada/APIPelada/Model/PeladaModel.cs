namespace APIPelada.Model
{
    public class PeladaModel
    {
        // public int IdPelada { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime? Data { get; set; }
        public string CodigoPelada { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public int QuantJogadorPorTime { get; set; }
    }
}
