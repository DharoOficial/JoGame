using JoGame_Pack.Context;
using JoGame_Pack.Interfaces;
using Microsoft.Data.SqlClient;
using JoGame_Pack.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoGame_Pack.Repositories
{
    public class JogoRepositorie : IJogo
    {
        ContextJoGame conexao = new ContextJoGame();

        SqlCommand cmd = new SqlCommand();

        public Jogo Alterar(Jogo j, int id)
        {


            cmd.CommandText = "UPDATE Jogo " +
               "SET Nome = @Nome, " +
               "Descricao = @Descricao " +
               "DataLancamento = @DataLancamento " +
               "WHERE JogoId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Nome", j.Nome);
            cmd.Parameters.AddWithValue("@Descricao", j.Descricao);
            cmd.Parameters.AddWithValue("@DataLancamento", j.DataLancamento);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return j;
        }

        public Jogo BuscarPorID(int Id)
        {
            conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Jogo WHERE JogoId = @id";
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            Jogo jogo = new Jogo();

            while (dados.Read())
            {
                jogo.JogoId = Convert.ToInt32(dados.GetValue(0));
                jogo.Nome = dados.GetValue(1).ToString();
                jogo.Descricao = dados.GetValue(2).ToString();
                jogo.DataLancamento = dados.GetValue(3).ToString();
            }

            conexao.Desconectar();
            return jogo;
        }

        public Jogo Cadastrar(Jogo j)
        {
            conexao.Conectar();
            cmd.CommandText =
              "INSERT INTO Jogador (Nome, Descricao, DataLancamento)" +
              "VALUES" +
              "(@Nome, @Descricao, @DataLancamento)";
            cmd.Parameters.AddWithValue("@Nome", j.Nome);
            cmd.Parameters.AddWithValue("@Descricao", j.Descricao);
            cmd.Parameters.AddWithValue("@DataLancamento", j.DataLancamento);

            cmd.ExecuteNonQuery();


            conexao.Desconectar();

            return j;
        }

        public Jogo Excluir(Jogo j, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "DELETE Jogo " +
              "WHERE JogoId = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conexao.Desconectar();

            return j;
        }

        public List<Jogo> ListarTodos()
        {
            conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Jogo";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Jogo> jogo = new List<Jogo>();

            while (dados.Read())
            {
                jogo.Add(
                    new Jogo()
                    {
                        JogoId = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        Descricao = dados.GetValue(2).ToString(),
                        DataLancamento = dados.GetValue(3).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return jogo;
        }
    }
}
