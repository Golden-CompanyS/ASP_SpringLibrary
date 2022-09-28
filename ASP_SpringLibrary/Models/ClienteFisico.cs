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

        /*public void cadCliF(ClienteFisico clienteF)
        {
            connection.Open();
            command.CommandText = "CALL spcadCliF(@CPFCliF, @dtNascCliF, @nomUsuCli, @senhaCli, @nomCli, @celCli, @emailCli, @CEPCli, @numEndCli, @compEndCli);";
                command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = clienteF.CPFCliF;
                command.Parameters.Add("@dtNascCliF", MySqlDbType.Date).Value = clienteF.dtNascCliF;
                command.Parameters.Add("@nomUsuCli", MySqlDbType.String).Value = clienteF.nomUsuCli;
                command.Parameters.Add("senhaCli", MySqlDbType.String).Value = clienteF.senhaCli;
                command.Parameters.Add("nomCli", MySqlDbType.String).Value = clienteF.nomCli;
                command.Parameters.Add("celCli", MySqlDbType.Int64).Value = clienteF.celCli;
                command.Parameters.Add("emailCli", MySqlDbType.Int64).Value = clienteF.emailCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.Int64).Value = clienteF.CEPCli;
                command.Parameters.Add("numEndCli", MySqlDbType.Int64).Value = clienteF.numEndCli;
                command.Parameters.Add("compEndCli", MySqlDbType.String).Value = clienteF.compEndCli;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public ClienteFisico checkCliF(int CPFCliF)
        {
            connection.Open();
            command.CommandText = "CALL spcheckCliF(@CPFCliF);";
                command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = CPFCliF;
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

        public void altCliF(ClienteFisico clienteF)
        {
            connection.Open();
            command.CommandText = "CALL spaltCliF(@CPFCliF, @dtNascCliF, @idCli, @nomUsuCli, @senhaCli, @nomCli, @celCli, @emailCli, @CEPCli, @numEndCli, @compEndCli);";
                command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = clienteF.CPFCliF;
                command.Parameters.Add("@dtNascCliF", MySqlDbType.Date).Value = clienteF.dtNascCliF;
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = clienteF.idCli;
                command.Parameters.Add("@nomUsuCli", MySqlDbType.String).Value = clienteF.nomUsuCli;
                command.Parameters.Add("senhaCli", MySqlDbType.String).Value = clienteF.senhaCli;
                command.Parameters.Add("nomCli", MySqlDbType.String).Value = clienteF.nomCli;
                command.Parameters.Add("celCli", MySqlDbType.Int64).Value = clienteF.celCli;
                command.Parameters.Add("emailCli", MySqlDbType.Int64).Value = clienteF.emailCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.Int64).Value = clienteF.CEPCli;
                command.Parameters.Add("numEndCli", MySqlDbType.Int64).Value = clienteF.numEndCli;
                command.Parameters.Add("compEndCli", MySqlDbType.String).Value = clienteF.compEndCli;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public void delCliF(int CPFCliF)
        {
            connection.Open();
            command.CommandText = "CALL spdelCliF(@CPFCliF);";
                command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = CPFCliF;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }*/
    }
}