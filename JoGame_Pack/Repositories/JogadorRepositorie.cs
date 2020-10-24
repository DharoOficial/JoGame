using Microsoft.Data.SqlClient;
using JoGame_Pack.Context;
using JoGame_Pack.Interfaces;
using JoGame_Pack.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoGame_Pack.Repositories
{
    public class JogadorRepositorie : IJogador
    {
        ContextJoGame conexao = new ContextJoGame();

        SqlCommand cmd = new SqlCommand();

        public Jogador Alterar(Jogador j, int id)
        {
           

            cmd.CommandText = "UPDATE Jogador " +
               "SET Nome = @Nome, " +
               "Email = @Email " +
               "Senha = @Senha " +
               "DataNascimento = @DataNascimento " +
               "WHERE PlayerId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Nome", j.Nome);
            cmd.Parameters.AddWithValue("@Email", j.Email);
            cmd.Parameters.AddWithValue("@Senha", j.Senha);
            cmd.Parameters.AddWithValue("@DataNascimento", j.DataNascimento);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return j;
        }

        public Jogador BuscarPorId(int id)
        {
            conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Jogador WHERE PlayerId = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Jogador jogador = new Jogador();

            while (dados.Read())
            {
                jogador.PlayerId = Convert.ToInt32(dados.GetValue(0));
                jogador.Nome = dados.GetValue(1).ToString();
                jogador.Email = dados.GetValue(2).ToString();
                jogador.Senha = dados.GetValue(3).ToString();
                jogador.DataNascimento = dados.GetValue(4).ToString();
            }

            conexao.Desconectar();
            return jogador;
        }

        public Jogador Cadastrar(Jogador j)
        {
            conexao.Conectar();
            cmd.CommandText =
              "INSERT INTO Jogador (Nome, Email, Senha, DataNascimento )" +
              "VALUES" +
              "(@Nome, @Email, @Senha, @DataNascimento )";
            cmd.Parameters.AddWithValue("@Nome", j.Nome);
            cmd.Parameters.AddWithValue("@Email", j.Email);
            cmd.Parameters.AddWithValue("@Senha", j.Senha);
            cmd.Parameters.AddWithValue("@DataNascimento", j.DataNascimento);

            cmd.ExecuteNonQuery();


            return j;

        }

        public Jogador Excluir(Jogador j, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "DELETE Jogador " +
              "WHERE PlayerID = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conexao.Desconectar();

            return j;
        }

        public List<Jogador> ListarTodos()
        {
            conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Jogador";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Jogador> jogador = new List<Jogador>();

            while (dados.Read())
            {
                jogador.Add(
                    new Jogador()
                    {
                        PlayerId = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        Email = dados.GetValue(2).ToString(),
                        Senha = dados.GetValue(3).ToString(),
                        DataNascimento = dados.GetValue(4).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return jogador;
        }
    }
}
