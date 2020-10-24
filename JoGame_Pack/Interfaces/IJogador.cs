using JoGame_Pack.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoGame_Pack.Interfaces
{
    interface IJogador
    {
        List<Jogador> ListarTodos();
        Jogador BuscarPorId(int id);
        Jogador Cadastrar(Jogador j);
        Jogador Alterar(Jogador j, int id);
        Jogador Excluir(Jogador j, int id);
    }
}
