using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class ClienteFisico : Cliente
    {
        public int CPFCliF { get; set; }
        public DateTime dtNascCliF { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public ClienteFisico checkCliF(int CPFCliF)
        {
            connection.Open();
            command.CommandText = "CALL spcheckCliF(@CPFCliF);";
            command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = idCli;
            var readClienteF = command.ExecuteReader();
            var tempClienteF = new ClienteFisico();

            if (readClienteF.Read())
            {
                tempClienteF.CPFCliF = int.Parse(readClienteF["CPFCliF"].ToString());
                tempClienteF.dtNascCliF = DateTime.Parse(readClienteF["dtNascCliF"].ToString());
                tempClienteF.idCli = int.Parse(readClienteF["idCli"].ToString());
                tempClienteF.nomUsuCli = readClienteF["nomUsuCli"].ToString();
                tempClienteF.senhaCli = readClienteF["senhaCli"].ToString();
                tempClienteF.nomCli = readClienteF["nomCli"].ToString();
                tempClienteF.celCli = int.Parse(readClienteF["celCli"].ToString());
                tempClienteF.emailCli = readClienteF["emailCli"].ToString();
                tempClienteF.CEPCli = int.Parse(readClienteF["CEPCli"].ToString());
                tempClienteF.numEndCli = int.Parse(readClienteF["numEndCli"].ToString());
                tempClienteF.compEndCli = readClienteF["compEndCli"].ToString();
            }

            readClienteF.Close();
            connection.Close();

            return tempClienteF;
        }

        public void delCliF(int CPFCliF)
        {
            connection.Open();
            command.CommandText = "CALL spdelCliF(@CPFCliF);";
                command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = CPFCliF;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}