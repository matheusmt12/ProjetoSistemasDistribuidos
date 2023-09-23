using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Jogador
    {
        public int IdJogadores { get; set; }
        public string Nome { get; set; }
        public int TimeIdTime { get; set; }
        public string PosicaoJogador { get; set; }
        public string Status { get; set; }

        public virtual Time TimeIdTimeNavigation { get; set; }
    }
}
