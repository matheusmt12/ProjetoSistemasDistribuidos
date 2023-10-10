using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core;
using Core.Service;
using System.Security.AccessControl;

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

        public async Task<Jogador> GetJogador(string userName, string senha)
        {
            try
            {
                return await _context.Jogadors
                .Where(g => g.UserName == userName && g.Senha == senha)
                .SingleOrDefaultAsync();
            }
            catch
            {
                return null;
            }

        }


    }
}