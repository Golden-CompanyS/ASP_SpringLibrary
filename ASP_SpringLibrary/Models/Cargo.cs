using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Cargo
    {
        public int idCarg { get; set; }
        public string nomCarg { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        /*public void cadCarg(Cargo cargo)
        {
            connection.Open();
            command.CommandText = "CALL spcadCarg(@nomCarg);";
                command.Parameters.Add("@nomCarg", MySqlDbType.String).Value = cargo.nomCarg;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void delCarg(int idCarg)
        {
            connection.Open();
            command.CommandText = "CALL spdelCarg(@idCarg);";
                command.Parameters.Add("@idCarg", MySqlDbType.Int64).Value = idCarg;
                command.ExecuteNonQuery();
            connection.Close();
        }*/
    }
}