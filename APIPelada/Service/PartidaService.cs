using Core;
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
    }
}
