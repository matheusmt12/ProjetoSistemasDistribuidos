using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PartidaService : IPartida
    {
        private readonly PeladaContext _context;
        
        public PartidaService(PeladaContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Partidum partidum)
        {
            try
            {
                await _context.AddAsync(partidum);
                await _context.SaveChangesAsync();
                return true;

                
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<PartidaDTO> GetAllPartidaEmAndamento()
        {
            return _context.Partida.Where(g => g.Status == true).Select( g => new PartidaDTO
            {
                InicioPartida = true,
                NomeTimeCasa = g.TimeIdTimeCasaNavigation.Nome,
                NomeTimeFora = g.TimeIdTimeForaNavigation.Nome,
                PlacarTimeCasa = g.PlacarTimeCasa,
                PlacarTimeFora = g.PlacarTimeFora,
                TempoDePartida = g.TempoDePartida,
                Status = true

            }).ToList();
        }

        public IEnumerable<PartidaDTO> GetAllPartidaEmcerradas()
        {
            return _context.Partida.Where(g => g.Status == false).Select(g => new PartidaDTO
            {
                InicioPartida = false,
                NomeTimeCasa = g.TimeIdTimeCasaNavigation.Nome,
                NomeTimeFora = g.TimeIdTimeForaNavigation.Nome,
                PlacarTimeCasa = g.PlacarTimeCasa,
                PlacarTimeFora = g.PlacarTimeFora,
                TempoDePartida = g.TempoDePartida,
                Status = false

            }).ToList();
        }

        public async Task<bool> Update(Partidum partidum)
        {
            try
            {
                _context.Update(partidum);
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
