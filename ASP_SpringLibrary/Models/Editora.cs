using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Editora
    {
        public int idEdit { get; set; }

        public int celEdit { get; set; }

        public string emailEdit { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadEdit(Editora editora)
        {
            connection.Open();
                command.CommandText = "CALL spcadEdit(@idEdit, @celEdit, @emailEdit);";
                command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = editora.idEdit;
                command.Parameters.Add("@celEdit", MySqlDbType.Int64).Value = editora.idEdit;
                command.Parameters.Add("emailEdit", MySqlDbType.String).Value = editora.emailEdit;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public void delEdit(int idEdit)
        {
            connection.Open();
                command.CommandText = "CALL spdelEdit(@idEdit);";
                command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = idEdit;
                command.ExecuteNonQuery();
            connection.Close();
        }
    }
}