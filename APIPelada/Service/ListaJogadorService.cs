using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Threading.Tasks;
using Core.DTO;

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

        public IEnumerable<ListaJogadorDTO> GetAll(string codPartida)
        {
            var query = _context.Listajogadors
                .Where(g => g.PeladaIdPeladaNavigation.CodigoPelada == codPartida)
                .Select(g => new ListaJogadorDTO
                {
                    Nome = g.JogadorIdJogadorNavigation.NomeJogador,
                    Posicao = g.JogadorIdJogadorNavigation.PosicaoJogador
                }).ToList();
            return query;

        }

        public bool GetByIdJogadorIdPelada(int idJogador, int idPelada)
        {
            var query = _context.Listajogadors
                .Where(g => g.PeladaIdPelada == idPelada && g.JogadorIdJogador == idJogador).FirstOrDefault();

            if (query == null) { return false; }
            return true;


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
