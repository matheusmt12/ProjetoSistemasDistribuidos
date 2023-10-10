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
            Times = new HashSet<Time>();
        }

        public int IdPelada { get; set; }
        public string Nome { get; set; }
        public DateTime? Data { get; set; }
        public string CodigoPelada { get; set; }
        public string Local { get; set; }
        public int QuantJogadorPorTime { get; set; }

        public virtual ICollection<Listajogador> Listajogadors { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}
