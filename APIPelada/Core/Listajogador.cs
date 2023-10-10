using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Listajogador
    {
        public int JogadorIdJogador { get; set; }
        public int PeladaIdPelada { get; set; }

        public virtual Jogador JogadorIdJogadorNavigation { get; set; }
        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
    }
}
