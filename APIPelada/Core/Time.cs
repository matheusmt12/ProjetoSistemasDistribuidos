using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTime { get; set; }
        public string Nome { get; set; }
        public int PeladaIdPelada { get; set; }
        public short? Vitorias { get; set; }
        public short? Derrota { get; set; }

        public virtual Peladum PeladaIdPeladaNavigation { get; set; }
        public virtual ICollection<Partidum> PartidumTimeIdTimeCasaNavigations { get; set; }
        public virtual ICollection<Partidum> PartidumTimeIdTimeForaNavigations { get; set; }
        public virtual ICollection<Timejogador> Timejogadors { get; set; }
    }
}
