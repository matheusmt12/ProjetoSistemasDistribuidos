using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IJogador
    {
        Task<bool>Create(Jogador jogador);

        Task<Jogador>GetJogador(int id);
    }
}
