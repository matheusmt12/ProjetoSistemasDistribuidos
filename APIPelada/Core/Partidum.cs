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
        public int PeladaIdPelada { get; set; }
        public int TimeIdTimeFora { get; set; }
        public int TimeIdTimeCasa { get; set; }

        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
        public virtual Time TimeIdTimeCasaNavigation { get; set; }
        public virtual Time TimeIdTimeForaNavigation { get; set; }
    }
}
