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

        public int IdJogador { get; set; }
        public string NomeJogador { get; set; }
        public string PosicaoJogador { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Listajogador> Listajogadors { get; set; }
        public virtual ICollection<Timejogador> Timejogadors { get; set; }
    }
}
