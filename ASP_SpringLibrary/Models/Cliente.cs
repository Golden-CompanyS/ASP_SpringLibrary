using ASP_SpringLibrary.Utils;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Cliente
    {
        public int idCli { get; set; }

        [Display(Name = "Nome")]
        public string nomCli { get; set; }

        [Display(Name = "Email")]
        public string emailCli { get; set; }

        [Display(Name = "Senha")]
        public string senhaCli { get; set; }

        [Display(Name = "Celular")]
        public string celCli { get; set; }

        [Display(Name = "CEP")]
        public string CEPCli { get; set; }

        [Display(Name = "Número")]
        public int numEndCli { get; set; }

        [Display(Name = "Complemento")]
        public string compEndCli { get; set; }

        [Display(Name = "Jurídico?")]
        public bool tipoCli { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public bool cliExists(int idCli, string docCli)
        {
            connection.Open();
            command.CommandText = "SELECT C.nomCli FROM tbCliente as C " +
                                  "     LEFT JOIN tbCliFis as F on C.idCli = F.idCli" +
                                  "     LEFT JOIN tbCliJur as J on C.idCli = J.idCli" +
                                  " WHERE C.idCli != @idCli and (CPFCliF = @docCli or CNPJCli = @docCli);";
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = idCli;
                command.Parameters.Add("@docCli", MySqlDbType.VarChar).Value = docCli;
                command.Connection = connection;
            string cli = (string) command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (cli.IsNullOrWhiteSpace())
                return false;
            else
                return true;
        }

        public bool emailExists(int idCli, string emailCli)
        {
            connection.Open();
            command.CommandText = "SELECT emailCli FROM tbCliente WHERE idCli != @idCli and emailCli = @emailCli;";
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = idCli;
                command.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = emailCli;
                command.Connection = connection;
            string email = (string) command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (email.IsNullOrWhiteSpace())
                return false;
            else
                return true;
        }

        public Cliente checkCliById(int idCli)
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbCliente WHERE idCli = @idCli;";
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = idCli;
                command.Connection = connection;
            var readCli = command.ExecuteReader();
            var tempCli = new Cliente();

            if (readCli.Read())
            {
                tempCli.idCli = int.Parse(readCli["idCli"].ToString());
                tempCli.nomCli = readCli["nomCli"].ToString();
                tempCli.emailCli = readCli["emailCli"].ToString();
                tempCli.celCli = readCli["celCli"].ToString();
                tempCli.CEPCli = readCli["CEPCli"].ToString();
                tempCli.numEndCli = int.Parse(readCli["numEndCli"].ToString());
                tempCli.compEndCli = readCli["compEndCli"].ToString();
                tempCli.tipoCli = bool.Parse(readCli["tipoCli"].ToString());
            }

            readCli.Close();
            connection.Close();

            return tempCli;
        }

        public int cliIdIfLoginExists(string email, string senha)
        {
            connection.Open();
            command.CommandText = "SELECT idCli, senhaCli FROM tbCliente WHERE emailCli = @email;";
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                command.Connection = connection;

            var readCli = command.ExecuteReader();
            var tempCli = new Cliente();

            if (readCli.Read())
            {
                tempCli.idCli = int.Parse(readCli["idCli"].ToString());
                tempCli.senhaCli = readCli["senhaCli"].ToString();
            }

            readCli.Close();
            connection.Close();

            if (Hash.CompareBCrypt(senha, tempCli.senhaCli))
            {
                return tempCli.idCli;
            }
            else
            {
                return 0;
            }
        }

        public bool isCli(string email)
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbCliente WHERE emailCli = @email;";
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                command.Connection = connection;

            var readCli = command.ExecuteReader();

            if (readCli.Read())
            {
                readCli.Close();
                connection.Close();
                return true;
            }
            else
            {
                readCli.Close();
                connection.Close();
                return false;
            }
        }
    }
}