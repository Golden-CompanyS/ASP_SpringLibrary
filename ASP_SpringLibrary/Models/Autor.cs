using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Models
{
    public class Autor
    {
        public int idAut { get; set; }

        [Display(Name = "Nome do(a) Autor(a)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O nome do(a) autor(a) deve ter até 100 caracteres")]
        [Remote("AutExists", "Autor", "Dashboard", AdditionalFields = "idAut", ErrorMessage = "O(a) autor(a) já existe!")]
        public string nomAut { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadAut(Autor autor)
        {
            connection.Open();
            command.CommandText = "CALL spcadAut(@nomAut);"; // INSERIR tbAutor
                command.Parameters.Add("@nomAut", MySqlDbType.VarChar).Value = autor.nomAut;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public bool autExists(int idAut, string nomAut)
        {
            connection.Open();
            command.CommandText = "SELECT nomAut FROM tbAutor WHERE idAut != @idAut and nomAut = @nomAut;";
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = idAut;
                command.Parameters.Add("@nomAut", MySqlDbType.VarChar).Value = nomAut;
                command.Connection = connection;
            string edit = (string) command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (edit.IsNullOrWhiteSpace())
                return false;
            else
                return true;
        }

        public void altAut(Autor autor)
        {
            connection.Open();
            command.CommandText = "CALL spaltAut(@idAut, @nomAut);"; // ALTERAR tbAutor
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = autor.idAut;
                command.Parameters.Add("@nomAut", MySqlDbType.VarChar).Value = autor.nomAut;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Autor> checkAllAut()
        {
            connection.Open();
            command.CommandText = "CALL spcheckAllAut();"; // SELECIONAR TUDO DA tbAutor
                command.Connection = connection;

            var readAut = command.ExecuteReader();
            List<Autor> tempAutList = new List<Autor>();

            while (readAut.Read())
            {
                var tempAut = new Autor();

                tempAut.idAut = int.Parse(readAut["idAut"].ToString());
                tempAut.nomAut = readAut["nomAut"].ToString();

                tempAutList.Add(tempAut);
            }

            readAut.Close();
            connection.Close();

            return tempAutList;
        }

        public Autor checkAutById(int idAut)
        {
            connection.Open();
            command.CommandText = "CALL spcheckAutById(@idAut);"; // SELECIONAR tbAutor PELO ID
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = idAut;
                command.Connection = connection;

            var readAut = command.ExecuteReader();
            var tempAut = new Autor();

            if (readAut.Read())
            {
                tempAut.idAut = int.Parse(readAut["idAut"].ToString());
                tempAut.nomAut = readAut["nomAut"].ToString();
            }

            readAut.Close();
            connection.Close();

            return tempAut;
        } 
    }
}