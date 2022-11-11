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

        [Display(Name = "Nº")]
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

        /*public bool 
            Hash.*/
    }
}