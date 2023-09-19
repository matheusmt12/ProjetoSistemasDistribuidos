using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class JogadorService : IJogador
    {
        private readonly PeladaContext _context;

        public JogadorService(PeladaContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Jogador jogador)
        {
            try
            {
                await _context.AddAsync(jogador);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;  
            }
        }

        public async Task<Jogador> GetJogador(int id)
        {

            try
            {
                var jogador = await _context.Jogadors.FindAsync(id);
                return jogador;
            }
            catch
            {
                return null;
            }

        }
    }
}
