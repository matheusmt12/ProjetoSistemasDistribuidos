using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
