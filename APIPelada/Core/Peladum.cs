using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Peladum
    {
        public Peladum()
        {
            Listajogadors = new HashSet<Listajogador>();
            Partida = new HashSet<Partidum>();
            Times = new HashSet<Time>();
        }

        public int IdPelada { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string CodigoPelada { get; set; }

        public virtual ICollection<Listajogador> Listajogadors { get; set; }
        public virtual ICollection<Partidum> Partida { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}
