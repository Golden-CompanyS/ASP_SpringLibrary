using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ASP_SpringLibrary.Models
{
    public class Genero
    {
        public int idGen { get; set; }

        [Display(Name = "Nome do Gênero")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O nome do gênero deve ter até 30 caracteres")]
        [Remote("GenExists", "Genero", "Dashboard", AdditionalFields = "idGen", ErrorMessage = "O gênero já existe!")]
        public string nomGen { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadGen(Genero genero)
        {
            connection.Open();
            command.CommandText = "CALL spcadGen(@nomGen);"; // INSERIR tbGenero
                command.Parameters.Add("@nomGen", MySqlDbType.VarChar).Value = genero.nomGen;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public bool genExists(int idGen, string nomGen)
        {
            connection.Open();
            command.CommandText = "SELECT nomGen FROM tbGenero WHERE idGen != @idGen and nomGen = @nomGen;";
                command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = idGen;
                command.Parameters.Add("@nomGen", MySqlDbType.VarChar).Value = nomGen;
                command.Connection = connection;
            string gen = (string) command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (gen.IsNullOrWhiteSpace())
                return false;
            else
                return true;
        }

        public void altGen(Genero genero)
        {
            connection.Open();
            command.CommandText = "CALL spaltGen(@idGen, @nomGen);";  // ALTERAR tbGenero
                command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = genero.idGen;
                command.Parameters.Add("@nomGen", MySqlDbType.VarChar).Value = genero.nomGen;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Genero> checkAllGen()
        {
            connection.Open();
            command.CommandText = "CALL spcheckAllGen();"; // SELECIONAR TUDO DA tbGenero
                command.Connection = connection;

            var readGen = command.ExecuteReader();
            List<Genero> tempGenList = new List<Genero>();

            while (readGen.Read())
            {
                var tempGen = new Genero();

                tempGen.idGen = int.Parse(readGen["idGen"].ToString());
                tempGen.nomGen = readGen["nomGen"].ToString();

                tempGenList.Add(tempGen);
            }

            readGen.Close();
            connection.Close();

            return tempGenList;
        }

        public Genero checkGenById(int idGen)
        {
            connection.Open();
            command.CommandText = "CALL spcheckGenById(@idGen);"; // SELECIONAR tbGenero PELO ID
                command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = idGen;
                command.Connection = connection;

            var readGen = command.ExecuteReader();
            var tempGen = new Genero();

            if (readGen.Read())
            {
                tempGen.idGen = int.Parse(readGen["idGen"].ToString());
                tempGen.nomGen = readGen["nomGen"].ToString();
            }

            readGen.Close();
            connection.Close();

            return tempGen;
        }
    }
}