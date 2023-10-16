using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class TimeJogadoreDTO
    {
        public string? NomeDoTime { get; set; }
        public List<string>? NomeDosJogadores { get; set; } = new List<string>();
    }
}
