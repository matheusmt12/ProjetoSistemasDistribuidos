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

        public bool GetByUserName(string userName)
        {
            var query = _context.Jogadors
                .Where(g => g.UserName == userName)
                .FirstOrDefault();

            if(query != null) { return true; }
            return false;
        }

        public Jogador? GetJogador(string nome)
        {
            try
            {
                return _context.Jogadors.Where(g => g.NomeJogador == nome)
                    .FirstOrDefault();

            }
            catch
            {
                return null;
            }

        }

        public Jogador Login(string username, string password)
        {
            try
            {
                var jogador = _context.Jogadors.Where(g => g.UserName == username && g.Senha == password)
                    .FirstOrDefault();
                if (jogador != null)
                    return jogador;
                return null;

            }
            catch
            {
                return null;
            }
        }
    }
}