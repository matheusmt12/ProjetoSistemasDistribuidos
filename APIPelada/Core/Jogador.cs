using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Jogador
    {
        public Jogador()
        {
            Listajogadors = new HashSet<Listajogador>();
            Timejogadors = new HashSet<Timejogador>();
        }

        public int IdListaJogador { get; set; }
        public string NomeJogador { get; set; }
        public string CodigoTorneio { get; set; }
        public string PosicaoJogador { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Listajogador> Listajogadors { get; set; }
        public virtual ICollection<Timejogador> Timejogadors { get; set; }
    }
}
