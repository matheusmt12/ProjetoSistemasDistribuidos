﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Listajogador
    {
        public int JogadorIdListaJogador { get; set; }
        public int PeladaIdPelada { get; set; }

        public virtual Jogador JogadorIdListaJogadorNavigation { get; set; }
        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
    }
}
