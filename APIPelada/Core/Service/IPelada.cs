using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPelada
    {
        Task<int> Create(Peladum peladum);

        Task<Peladum> Get(int id);

        int GetPeladaByCod(string codigo);
    }
}
