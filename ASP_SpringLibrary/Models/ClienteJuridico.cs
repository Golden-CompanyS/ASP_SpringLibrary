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
    public class ClienteJuridico : Cliente
    {
        [Display(Name = "CPNJ")]
        public string CNPJCliJ { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string fantaCliJ { get; set; }

        [Display(Name = "Representante")]
        public string represCliJ { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadCliJ(ClienteJuridico clienteJ)
        {
            connection.Open();
            command.CommandText = "CALL spcadCliJur(@nomCli, @celCli, @emailCli, @senhaCli, @CEPCli, @numEndCli, @compEndCli, @CNPJCliJ, @fantaCliJ, @represCliJ);";
                command.Parameters.Add("@nomCli", MySqlDbType.VarChar).Value = clienteJ.nomCli;
                command.Parameters.Add("@celCli", MySqlDbType.VarChar).Value = clienteJ.celCli;
                command.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = clienteJ.emailCli;
                command.Parameters.Add("@senhaCli", MySqlDbType.VarChar).Value = clienteJ.senhaCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.VarChar).Value = clienteJ.CEPCli;
                command.Parameters.Add("@numEndCli", MySqlDbType.Int64).Value = clienteJ.numEndCli;
                command.Parameters.Add("@compEndCli", MySqlDbType.VarChar).Value = clienteJ.compEndCli;
                command.Parameters.Add("@CNPJCliJ", MySqlDbType.VarChar).Value = clienteJ.CNPJCliJ;
                command.Parameters.Add("@fantaCliJ", MySqlDbType.VarChar).Value = clienteJ.fantaCliJ;
                command.Parameters.Add("@represCliJ", MySqlDbType.VarChar).Value = clienteJ.represCliJ;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public void altCliJ(ClienteJuridico clienteJ)
        {
            connection.Open();
            command.CommandText = "CALL spaltCliJur(@idCli, @nomCli, @celCli, @emailCli, @senhaCli, @CEPCli, @numEndCli, @compEndCli, @CNPJCliJ, @fantaCliJ0, @represCliJ);";
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = clienteJ.idCli;
                command.Parameters.Add("@nomCli", MySqlDbType.VarChar).Value = clienteJ.nomCli;
                command.Parameters.Add("@celCli", MySqlDbType.VarChar).Value = clienteJ.celCli;
                command.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = clienteJ.emailCli;
                command.Parameters.Add("@senhaCli", MySqlDbType.VarChar).Value = clienteJ.senhaCli;
                command.Parameters.Add("@CEPCli", MySqlDbType.VarChar).Value = clienteJ.CEPCli;
                command.Parameters.Add("@numEndCli", MySqlDbType.Int64).Value = clienteJ.numEndCli;
                command.Parameters.Add("@compEndCli", MySqlDbType.VarChar).Value = clienteJ.compEndCli;
                command.Parameters.Add("@CNPJCliJ", MySqlDbType.VarChar).Value = clienteJ.CNPJCliJ;
                command.Parameters.Add("@fantaCliJ", MySqlDbType.Date).Value = clienteJ.fantaCliJ;
                command.Parameters.Add("@represCliJ", MySqlDbType.Date).Value = clienteJ.represCliJ;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public List<ClienteJuridico> checkAllCliJ()
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbCliente INNER JOIN tbCliJur on tbCliente.idCli = tbCliJur.idCli ORDER BY tbCliente.idCli;";
            command.Connection = connection;

            var readCliJ = command.ExecuteReader();
            List<ClienteJuridico> tempCliJList = new List<ClienteJuridico>();

            while (readCliJ.Read())
            {
                var tempCliJ = new ClienteJuridico();

                tempCliJ.idCli = int.Parse(readCliJ["idCli"].ToString());
                tempCliJ.nomCli = readCliJ["nomCli"].ToString();
                tempCliJ.tipoCli = readCliJ["tipoCli"].ToString().AsBool();
                tempCliJ.celCli = readCliJ["celCli"].ToString();
                tempCliJ.emailCli = readCliJ["emailCli"].ToString();
                tempCliJ.senhaCli = readCliJ["senhaCli"].ToString();
                tempCliJ.CEPCli = readCliJ["CEPCli"].ToString();
                tempCliJ.numEndCli = int.Parse(readCliJ["numEndCli"].ToString());
                tempCliJ.compEndCli = readCliJ["compEndCli"].ToString();
                tempCliJ.CNPJCliJ = readCliJ["CNPJCli"].ToString();
                tempCliJ.fantaCliJ = readCliJ["fantaCliJ"].ToString();
                tempCliJ.represCliJ = readCliJ["represCliJ"].ToString();

                tempCliJList.Add(tempCliJ);
            }

            readCliJ.Close();
            connection.Close();

            return tempCliJList;
        }

        public ClienteJuridico checkCliJ(int CNPJCliJ)
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbCliente INNER JOIN tbCliJur on tbCliente.idCli = tbCliJur.idCli WHERE tbCliJur.CNPJCli = @CNPJCli ORDER BY tbCliente.idCli;";
            command.Parameters.Add("@CNPJCli", MySqlDbType.VarChar).Value = CNPJCliJ;
            var readCliJ = command.ExecuteReader();
            var tempCliJ = new ClienteJuridico();

            if (readCliJ.Read())
            {
                tempCliJ.idCli = int.Parse(readCliJ["idCli"].ToString());
                tempCliJ.nomCli = readCliJ["nomCli"].ToString();
                tempCliJ.tipoCli = readCliJ["tipoCli"].ToString().AsBool();
                tempCliJ.celCli = readCliJ["celCli"].ToString();
                tempCliJ.emailCli = readCliJ["emailCli"].ToString();
                tempCliJ.senhaCli = readCliJ["senhaCli"].ToString();
                tempCliJ.CEPCli = readCliJ["CEPCli"].ToString();
                tempCliJ.numEndCli = int.Parse(readCliJ["numEndCli"].ToString());
                tempCliJ.compEndCli = readCliJ["compEndCli"].ToString();
                tempCliJ.CNPJCliJ = readCliJ["CPFCliF"].ToString();
                tempCliJ.fantaCliJ = readCliJ["fantaCliJ"].ToString();
                tempCliJ.represCliJ = readCliJ["represCliJ"].ToString();
            }

            readCliJ.Close();
            connection.Close();

            return tempCliJ;
        }
    }
}