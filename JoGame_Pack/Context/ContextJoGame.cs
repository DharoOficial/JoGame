using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JoGame_Pack.Context
{
    public class ContextJoGame
    {

        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
        public ContextJoGame()
        {
            con.ConnectionString = @"Data Source=DESKTOP-TSI8JUU\SQLEXPRESS;Initial Catalog=JoGame;Persist Security Info=True;User ID=sa;Password=sa132";
        }

        public System.Data.SqlClient.SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
