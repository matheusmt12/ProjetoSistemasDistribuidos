using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Partidum
    {
        public int IdPartida { get; set; }
        public string PlacarTimeCasa { get; set; }
        public string PlacarTimeFora { get; set; }
        public int TimeIdTime { get; set; }
        public int PeladaIdPelada { get; set; }

        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
        public virtual Time TimeIdTimeNavigation { get; set; }
    }
}
