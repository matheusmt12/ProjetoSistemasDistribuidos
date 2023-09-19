using APIPelada.Model;
using AutoMapper;
using Core;

namespace APIPelada.Mappers
{
    public class JogadorProfile : Profile
    {
        public JogadorProfile()
        {
            CreateMap<JogadorModel, Jogador>().ReverseMap();
        }
    }
}
