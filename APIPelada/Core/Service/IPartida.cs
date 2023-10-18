using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPartida
    {
        Task<bool> Create(Partidum partidum);
        Task<bool> Update(Partidum partidum);

        IEnumerable<PartidaDTO> GetAllPartidaEmAndamento();

        IEnumerable<PartidaDTO> GetAllPartidaEmcerradas();
    }
}
