using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Time
    {
        public Time()
        {
            PartidumTimeIdTimeCasaNavigations = new HashSet<Partidum>();
            PartidumTimeIdTimeForaNavigations = new HashSet<Partidum>();
            Timejogadors = new HashSet<Timejogador>();
        }

        public int IdTime { get; set; }
        public string Nome { get; set; }
        public int PeladaIdPelada { get; set; }

        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
        public virtual ICollection<Partidum> PartidumTimeIdTimeCasaNavigations { get; set; }
        public virtual ICollection<Partidum> PartidumTimeIdTimeForaNavigations { get; set; }
        public virtual ICollection<Timejogador> Timejogadors { get; set; }
    }
}
