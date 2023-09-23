using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Listajogador
    {
        public int IdListaJogador { get; set; }
        public string NomeJogador { get; set; }
        public string CodigoTorneio { get; set; }
        public int PeladaIdPelada { get; set; }
        public string PosicaoJogador { get; set; }
        public string Status { get; set; }

        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
    }
}
