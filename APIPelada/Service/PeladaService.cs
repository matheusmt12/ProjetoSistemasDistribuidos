using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;

namespace Service
{
    public class PeladaService : IPelada
    {

        private readonly PeladaContext _context;

        public PeladaService(PeladaContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Peladum peladum)
        {



            await _context.AddAsync(peladum);
            await _context.SaveChangesAsync();

            return peladum.IdPelada;


        }

        public async Task<Peladum> Get(int id)
        {
            return await _context.Pelada.FindAsync(id);
        }

        public int GetPeladaByCod(string codigo)
        {
            return _context.Pelada.Where(p => p.CodigoPelada.Equals(codigo)).Select(g => g.IdPelada).FirstOrDefault();
        }
    }
}
