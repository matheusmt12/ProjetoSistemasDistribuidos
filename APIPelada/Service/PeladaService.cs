﻿using System;
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

        public async Task<int> GetIdPelada(string codigo)
        {
            return await _context.Pelada.Where(g => g.CodigoPelada == codigo)
                .Select( g => g.IdPelada).FirstOrDefaultAsync();
        }
    }
}
