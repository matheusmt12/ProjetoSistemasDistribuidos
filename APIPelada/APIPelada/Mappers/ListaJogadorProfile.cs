using APIPelada.Model;
using AutoMapper;
using Core;

namespace APIPelada.Mappers
{
    public class ListaJogadorProfile : Profile
    {
        public ListaJogadorProfile()
        {
            CreateMap<ListaJogadorModel,Listajogador>().ReverseMap();
        }
    }
}
