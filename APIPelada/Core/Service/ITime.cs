using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITime
    {
        Task<int> Create(Time time);
        int GetQtdTimes(int idPelada);
        Task<bool> CreateTime(Timejogador timejogador);
        IEnumerable<Time> GetTimes(int idPelada);
        Task<bool> DeleteTime(int idTime);

    }
}
