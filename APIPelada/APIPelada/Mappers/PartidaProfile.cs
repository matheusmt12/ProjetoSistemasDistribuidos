using APIPelada.Model;
using AutoMapper;
using Core;

namespace APIPelada.Mappers
{
    public class PartidaProfile : Profile
    {
        public PartidaProfile()
        {
            CreateMap<PartidaModel,Partidum>().ReverseMap();
        }
    }
}
