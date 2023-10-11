using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class ListaJogadorService : IListaJogador
    {
        private readonly PeladaContext _context;

        public ListaJogadorService(PeladaContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Listajogador listajogador)
        {

            try
            {
                await _context.AddAsync(listajogador);
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Listajogador> GetAll()
        {
            return  _context.Listajogadors.ToList();




        }

        public int GetIdPelada(string codigo)
        {
            try
            {
                var query = _context.Pelada
                    .Where(g => g.CodigoPelada == codigo)
                    .Select(g => g.IdPelada).FirstOrDefault();


                return query;
            }
            catch
            {
                return 0;
            }
        }
    }
}
