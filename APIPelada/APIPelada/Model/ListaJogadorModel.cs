namespace APIPelada.Model
{
    public class ListaJogadorModel
    {
        //public int IdListaJogador { get; set; }
        public string NomeJogador { get; set; } = string.Empty;
        public string CodigoTorneio { get; set; } = string.Empty;
        public int PeladaIdPelada { get; set; }
        public string PosicaoJogador { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
