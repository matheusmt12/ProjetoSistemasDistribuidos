using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TimeService : ITime
    {

        private readonly PeladaContext _context;

        public TimeService(PeladaContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Time time)
        {
            try
            {
                await _context.AddAsync(time);
                await _context.SaveChangesAsync();
                return time.IdTime;
            }
            catch
            {
                return 0;
            }
        }

        public int GetQtdTimes(int idPelada)
        {
            try
            {
                var query = _context.Times.Where(time => time.PeladaIdPelada == idPelada);
                var list = query.ToList();
                return list.Count;
            }
            catch { 
                return 0; 
            }
        }

        public async Task<bool> CreateTime(Timejogador timejogador)
        {
            try
            {
                await _context.Timejogadors.AddAsync(timejogador);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
           

        }

        public IEnumerable<Time> GetTimes(int idPelada)
        {
           var query = _context.Times.Where(g => g.PeladaIdPelada == idPelada).ToList();
            return query;
        }

        public async Task<bool> DeleteTime(int idTime)
        {
            try{
                var jogadoresParaExcluir = _context.Timejogadors
                .Where(j => j.TimeIdTime == idTime)
                .ToList();

                if (jogadoresParaExcluir.Any())
                {
                    _context.Timejogadors.RemoveRange(jogadoresParaExcluir);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

    }
}
