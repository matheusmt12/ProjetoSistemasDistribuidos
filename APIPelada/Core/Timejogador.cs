using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Timejogador
    {
        public int TimeIdTime { get; set; }
        public int JogadorIdJogador { get; set; }

        public virtual Jogador JogadorIdJogadorNavigation { get; set; }
        public virtual Time TimeIdTimeNavigation { get; set; }
    }
}
