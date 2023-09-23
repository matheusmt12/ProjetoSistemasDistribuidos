using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Time
    {
        public Time()
        {
            Jogadors = new HashSet<Jogador>();
            PartidumTimeIdTimeCasaNavigations = new HashSet<Partidum>();
            PartidumTimeIdTimeForaNavigations = new HashSet<Partidum>();
        }

        public int IdTime { get; set; }
        public string Nome { get; set; }
        public int PeladaIdPelada { get; set; }

        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
        public virtual ICollection<Jogador> Jogadors { get; set; }
        public virtual ICollection<Partidum> PartidumTimeIdTimeCasaNavigations { get; set; }
        public virtual ICollection<Partidum> PartidumTimeIdTimeForaNavigations { get; set; }
    }
}
