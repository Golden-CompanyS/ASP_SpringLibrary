using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Cliente
    {
        public int idCli { get; set; }
        public string nomUsuCli { get; set; }
        public string senhaCli { get; set; }
        public string nomCli { get; set; }
        public int celCli { get; set; }
        public string emailCli { get; set; }
        public int CEPCli { get; set; }
        public int numEndCli { get; set; }
        public string compEndCli { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadCli(Cliente cliente)
        {
            connection.Open();
            command.CommandText = "CALL spcadCli(@nomUsuCli, @senhaCli, @nomCli, @celCli, @emailCli, @CEPCli, @numEndCli, @compEndCli);";
                command.Parameters.Add("@nomUsuCli", MySqlDbType.String).Value = cliente.nomUsuCli;
                command.Parameters.Add("senhaCli", MySqlDbType.String).Value = cliente.senhaCli;
                command.Parameters.Add("nomCli", MySqlDbType.String).Value = cliente.nomCli;
                command.Parameters.Add("celCli", MySqlDbType.Int64).Value = cliente.celCli;
                command.Parameters.Add("emailCli", MySqlDbType.Int64).Value = cliente.emailCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.Int64).Value = cliente.CEPCli;
                command.Parameters.Add("numEndCli", MySqlDbType.Int64).Value = cliente.numEndCli;
                command.Parameters.Add("compEndCli", MySqlDbType.String).Value = cliente.compEndCli;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void altCli(Cliente cliente)
        {
            connection.Open();
            command.CommandText = "CALL spaltCli(@idCli, @nomUsuCli, @senhaCli, @nomCli, @celCli, @emailCli, @CEPCli, @numEndCli, @compEndCli);";
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = cliente.idCli;
                command.Parameters.Add("@nomUsuCli", MySqlDbType.String).Value = cliente.nomUsuCli;
                command.Parameters.Add("senhaCli", MySqlDbType.String).Value = cliente.senhaCli;
                command.Parameters.Add("nomCli", MySqlDbType.String).Value = cliente.nomCli;
                command.Parameters.Add("celCli", MySqlDbType.Int64).Value = cliente.celCli;
                command.Parameters.Add("emailCli", MySqlDbType.Int64).Value = cliente.emailCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.Int64).Value = cliente.CEPCli;
                command.Parameters.Add("numEndCli", MySqlDbType.Int64).Value = cliente.numEndCli;
                command.Parameters.Add("compEndCli", MySqlDbType.String).Value = cliente.compEndCli;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}