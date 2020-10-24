using JoGame_Pack.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoGame_Pack.Interfaces
{
    interface IJogo
    {
        List<Jogo> ListarTodos();
        Jogo BuscarPorID(int Id);
        Jogo Cadastrar(Jogo j);
        Jogo Alterar(Jogo j, int id);
        Jogo Excluir(Jogo j, int id);

    }
}
