using APIPelada.Model;
using AutoMapper;

namespace APIPelada.Mappers
{
    public class Jogador : Profile
    {
        public Jogador()
        {
            CreateMap<JogadorModel, Jogador>().ReverseMap();
        }
    }
}
