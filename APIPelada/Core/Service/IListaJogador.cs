using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IListaJogador
    {
        Task<bool> Create(Listajogador listajogador);
        int GetIdPelada(string codigoPelada);
        IEnumerable<ListaJogadorDTO> GetAll(string codPartida);
        bool GetByIdJogadorIdPelada (int idJogador,int idPelada);
        IEnumerable<Listajogador> GetAllJogadores(int idPelada);

    }
}
