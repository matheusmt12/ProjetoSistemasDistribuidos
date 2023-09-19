using APIPelada.Model;
using AutoMapper;
using Core;

namespace APIPelada.Mappers
{
    public class PeladaProfile : Profile
    {
        public PeladaProfile()
        {
            CreateMap<PeladaModel,Peladum>().ReverseMap();
        }
    }
}
