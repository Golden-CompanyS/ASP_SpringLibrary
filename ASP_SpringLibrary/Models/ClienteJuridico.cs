using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class ClienteJuridico : Cliente
    {
        public int CNPJCliJ { get; set; }
        public string fantaCliJ { get; set; }
        public string represCliJ { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        /*public void cadCliJ(ClienteJuridico clienteJ)
        {
            connection.Open();
            command.CommandText = "CALL spcadCliJ(@CNPJCliJ, @fantaCliJ, @represCliJ, @nomUsuCli, @senhaCli, @nomCli, @celCli, @emailCli, @CEPCli, @numEndCli, @compEndCli);";
                command.Parameters.Add("@CNPJCliJ", MySqlDbType.Int64).Value = clienteJ.CNPJCliJ;
                command.Parameters.Add("@fantaCliJ", MySqlDbType.String).Value = clienteJ.fantaCliJ;
                command.Parameters.Add("@represCliJ", MySqlDbType.String).Value = clienteJ.represCliJ;
                command.Parameters.Add("@nomUsuCli", MySqlDbType.String).Value = clienteJ.nomUsuCli;
                command.Parameters.Add("senhaCli", MySqlDbType.String).Value = clienteJ.senhaCli;
                command.Parameters.Add("nomCli", MySqlDbType.String).Value = clienteJ.nomCli;
                command.Parameters.Add("celCli", MySqlDbType.Int64).Value = clienteJ.celCli;
                command.Parameters.Add("emailCli", MySqlDbType.Int64).Value = clienteJ.emailCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.Int64).Value = clienteJ.CEPCli;
                command.Parameters.Add("numEndCli", MySqlDbType.Int64).Value = clienteJ.numEndCli;
                command.Parameters.Add("compEndCli", MySqlDbType.String).Value = clienteJ.compEndCli;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public ClienteJuridico checkCliJ(int CNPJCliJ)
        {
            connection.Open();
            command.CommandText = "CALL spcheckCliJ(@CNPJCliJ);";
                command.Parameters.Add("@CNPJCliJ", MySqlDbType.Int64).Value = CNPJCliJ;
            var readClienteJ = command.ExecuteReader();
            var tempClienteJ = new ClienteJuridico();

            if (readClienteJ.Read())
            {
                tempClienteJ.CNPJCliJ = int.Parse(readClienteJ["CNPJCliJ"].ToString());
                tempClienteJ.fantaCliJ = readClienteJ["fantaCliJ"].ToString();
                tempClienteJ.represCliJ = readClienteJ["represCliJ"].ToString();
                tempClienteJ.idCli = int.Parse(readClienteJ["idCli"].ToString());
                tempClienteJ.nomUsuCli = readClienteJ["nomUsuCli"].ToString();
                tempClienteJ.senhaCli = readClienteJ["senhaCli"].ToString();
                tempClienteJ.nomCli = readClienteJ["nomCli"].ToString();
                tempClienteJ.celCli = int.Parse(readClienteJ["celCli"].ToString());
                tempClienteJ.emailCli = readClienteJ["emailCli"].ToString();
                tempClienteJ.CEPCli = int.Parse(readClienteJ["CEPCli"].ToString());
                tempClienteJ.numEndCli = int.Parse(readClienteJ["numEndCli"].ToString());
                tempClienteJ.compEndCli = readClienteJ["compEndCli"].ToString();
            }

            readClienteJ.Close();
            connection.Close();

            return tempClienteJ;
        }

        public void altCliF(ClienteJuridico clienteJ)
        {
            connection.Open();
            command.CommandText = "CALL spaltCliF(@CNPJCliJ, @fantaCliJ, @represCliJ, @idCli, @nomUsuCli, @senhaCli, @nomCli, @celCli, @emailCli, @CEPCli, @numEndCli, @compEndCli);";
                command.Parameters.Add("@CNPJCliJ", MySqlDbType.Int64).Value = clienteJ.CNPJCliJ;
                command.Parameters.Add("@fantaCliJ", MySqlDbType.String).Value = clienteJ.fantaCliJ;
                command.Parameters.Add("@represCliJ", MySqlDbType.String).Value = clienteJ.represCliJ;
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = clienteJ.idCli;
                command.Parameters.Add("@nomUsuCli", MySqlDbType.String).Value = clienteJ.nomUsuCli;
                command.Parameters.Add("senhaCli", MySqlDbType.String).Value = clienteJ.senhaCli;
                command.Parameters.Add("nomCli", MySqlDbType.String).Value = clienteJ.nomCli;
                command.Parameters.Add("celCli", MySqlDbType.Int64).Value = clienteJ.celCli;
                command.Parameters.Add("emailCli", MySqlDbType.Int64).Value = clienteJ.emailCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.Int64).Value = clienteJ.CEPCli;
                command.Parameters.Add("numEndCli", MySqlDbType.Int64).Value = clienteJ.numEndCli;
                command.Parameters.Add("compEndCli", MySqlDbType.String).Value = clienteJ.compEndCli;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public void delCliF(int CNPJCliJ)
        {
            connection.Open();
            command.CommandText = "CALL spdelCliF(@CPFCliF);";
                command.Parameters.Add("@CPFCliF", MySqlDbType.Int64).Value = CNPJCliJ;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }*/
    }
}