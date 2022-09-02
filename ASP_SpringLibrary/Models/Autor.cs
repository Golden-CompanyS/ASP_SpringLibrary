using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Autor
    {
        public int idAut { get; set; }

        //[Required]
        //[MaxLength(30, ErrorMessage="Limite de 30 caracteres excedido.")]
        public string nomAut { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadAut(Autor autor)
        {
            connection.Open();
            command.CommandText = "CALL spcadAut(@nomAut);";
                command.Parameters.Add("@nomAut", MySqlDbType.String).Value = autor.nomAut;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Autor checkAut(int idAut)
        {
            connection.Open();
;           command.CommandText = "CALL spXXXX(@xxx);";
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = idAut;
                command.Connection = connection;
            var readAutor = command.ExecuteReader();
            var tempAutor = new Autor();

            if (readAutor.Read())
            {
                tempAutor.idAut = int.Parse(readAutor["idAut"].ToString());
                tempAutor.nomAut = readAutor["nomAut"].ToString();
            };

            readAutor.Close();
            connection.Close();

            return tempAutor;
        }

        public void altAut(Autor autor)
        {
            connection.Open();
            command.CommandText = "CALL spaltAut(@idAut, @nomAut);";
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = autor.nomAut;
                command.Parameters.Add("@nomAut", MySqlDbType.String).Value = autor.nomAut;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void delAut(int idAut)
        {
            connection.Open();
            command.CommandText = "CALL delAut(@idAut);";
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = idAut;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}