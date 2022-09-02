using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Genero
    {
        public int idGen { get; set; }
        public string nomGen { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadGen(Genero genero)
        {
            connection.Open();
                command.CommandText = "CALL spcadGen(@nomGen);";
                command.Parameters.Add("@nomGen", MySqlDbType.Int64).Value = genero.nomGen;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void delGen(int idGen)
        {
            connection.Open();
                command.CommandText = "CALL spdelGen(@idGen);";
                command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = idGen;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}