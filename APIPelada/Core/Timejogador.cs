using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Timejogador
    {
        public int TimeIdTime { get; set; }
        public int JogadorIdListaJogador { get; set; }

        public virtual Jogador JogadorIdListaJogadorNavigation { get; set; }
        public virtual Time TimeIdTimeNavigation { get; set; }
    }
}
