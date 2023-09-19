using APIPelada.Model;
using AutoMapper;
using MySqlX.XDevAPI.CRUD;

namespace APIPelada.Mappers
{
    public class ListaJogador : Profile
    {
        public ListaJogador()
        {
            CreateMap<ListaJogadorModel, ListaJogador>().ReverseMap();
        }
    }
}
