using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TimeService : ITime
    {

        private readonly PeladaContext _context;

        public TimeService(PeladaContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Time time)
        {
            try
            {
                await _context.AddAsync(time);
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
