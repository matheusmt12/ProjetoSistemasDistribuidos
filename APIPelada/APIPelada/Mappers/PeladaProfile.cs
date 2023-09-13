using APIPelada.Model;
using AutoMapper;
using Core;
using Core.Service;
using Service;

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
