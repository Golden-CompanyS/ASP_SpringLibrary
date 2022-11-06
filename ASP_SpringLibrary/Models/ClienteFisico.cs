using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace ASP_SpringLibrary.Models
{
    public class ClienteFisico : Cliente
    {
        [Display(Name = "CPF")]
        public string CPFCliF { get; set; }

        [Display(Name = "Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtNascCliF { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadCliF(ClienteFisico clienteF)
        {
            connection.Open();
            command.CommandText = "CALL spcadCliFis(@nomCli, @celCli, @emailCli, @senhaCli, @CEPCli, @numEndCli, @compEndCli, @CPFCliF, @dtNascCliF);";
                command.Parameters.Add("@nomCli", MySqlDbType.VarChar).Value = clienteF.nomCli;
                command.Parameters.Add("@celCli", MySqlDbType.VarChar).Value = clienteF.celCli;
                command.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = clienteF.emailCli;
                command.Parameters.Add("@senhaCli", MySqlDbType.VarChar).Value = clienteF.senhaCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.VarChar).Value = clienteF.CEPCli;
                command.Parameters.Add("@numEndCli", MySqlDbType.Int64).Value = clienteF.numEndCli;
                command.Parameters.Add("@compEndCli", MySqlDbType.VarChar).Value = clienteF.compEndCli;
                command.Parameters.Add("@CPFCliF", MySqlDbType.VarChar).Value = clienteF.CPFCliF;
                command.Parameters.Add("@dtNascCliF", MySqlDbType.Date).Value = clienteF.dtNascCliF; // STR_TO_DATE(@dtNascCliF, '%d/%m/%Y %T')
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void altCliF(ClienteFisico clienteF)
        {
            connection.Open();
            command.CommandText = "CALL spaltCliFis(@idCli, @nomCli, @celCli, @emailCli, @senhaCli, @CEPCli, @numEndCli, @compEndCli, @CPFCliF, @dtNascCliF);";
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = clienteF.idCli;
                command.Parameters.Add("@nomCli", MySqlDbType.VarChar).Value = clienteF.nomCli;
                command.Parameters.Add("@celCli", MySqlDbType.VarChar).Value = clienteF.celCli;
                command.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = clienteF.emailCli;
                command.Parameters.Add("@senhaCli", MySqlDbType.VarChar).Value = clienteF.senhaCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.VarChar).Value = clienteF.CEPCli;
                command.Parameters.Add("@numEndCli", MySqlDbType.Int64).Value = clienteF.numEndCli;
                command.Parameters.Add("@compEndCli", MySqlDbType.VarChar).Value = clienteF.compEndCli;
                command.Parameters.Add("@CPFCliF", MySqlDbType.VarChar).Value = clienteF.CPFCliF;
                command.Parameters.Add("@dtNascCliF", MySqlDbType.Date).Value = clienteF.dtNascCliF; // STR_TO_DATE(@dtNascCliF, '%d/%m/%Y %T')
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<ClienteFisico> checkAllCliF()
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbCliente INNER JOIN tbCliFis on tbCliente.idCli = tbCliFis.idCli;";
                command.Connection = connection;

            var readCliF = command.ExecuteReader();
            List<ClienteFisico> tempCliFList = new List<ClienteFisico>();

            while (readCliF.Read())
            {
                var tempCliF = new ClienteFisico();

                tempCliF.idCli = int.Parse(readCliF["idCli"].ToString());
                tempCliF.nomCli = readCliF["nomCli"].ToString();
                tempCliF.tipoCli = readCliF["tipoCli"].ToString().AsBool();
                tempCliF.celCli = readCliF["celCli"].ToString();
                tempCliF.emailCli = readCliF["emailCli"].ToString();
                tempCliF.senhaCli = readCliF["senhaCli"].ToString();
                tempCliF.CEPCli = readCliF["CEPCli"].ToString();
                tempCliF.numEndCli = int.Parse(readCliF["numEndCli"].ToString());
                tempCliF.compEndCli = readCliF["compEndCli"].ToString();
                tempCliF.CPFCliF = readCliF["CPFCliF"].ToString();
                tempCliF.dtNascCliF = DateTime.Parse(readCliF["dtNascCliF"].ToString());


                tempCliFList.Add(tempCliF);
            }

            readCliF.Close();
            connection.Close();

            return tempCliFList;
        }

        public ClienteFisico checkCliF(int CPFCliF)
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbCliente INNER JOIN tbCliFis on tbCliente.idCli = tbCliFis.idCli WHERE tbCliFis.CPFCli = @CPFCli;";
                command.Parameters.Add("@CPFCliF", MySqlDbType.VarChar).Value = CPFCliF;
            var readCliF = command.ExecuteReader();
            var tempCliF = new ClienteFisico();

            if (readCliF.Read())
            {
                tempCliF.idCli = int.Parse(readCliF["idCli"].ToString());
                tempCliF.nomCli = readCliF["nomCli"].ToString();
                tempCliF.tipoCli = readCliF["tipoCli"].ToString().AsBool();
                tempCliF.celCli = readCliF["celCli"].ToString();
                tempCliF.emailCli = readCliF["emailCli"].ToString();
                tempCliF.senhaCli = readCliF["senhaCli"].ToString();
                tempCliF.CEPCli = readCliF["CEPCli"].ToString();
                tempCliF.numEndCli = int.Parse(readCliF["numEndCli"].ToString());
                tempCliF.compEndCli = readCliF["compEndCli"].ToString();
                tempCliF.CPFCliF = readCliF["CPFCliF"].ToString();
                tempCliF.dtNascCliF = DateTime.Parse(readCliF["dtNascCliF"].ToString());
            }

            readCliF.Close();
            connection.Close();

            return tempCliF;
        }
    }
}