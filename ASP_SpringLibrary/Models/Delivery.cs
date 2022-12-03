using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Delivery
    {
        public int idDel { get; set; }

        [Display(Name = "Previsão de Entrega")]
        public DateTime dtPrevDel { get; set; }

        [Display(Name = "Data Entregue")]
        public DateTime? dtEntDel { get; set; }

        [Display(Name = "Status")]
        public char statDel { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void altStatusDeliv(int idDel, int status)
        {
            connection.Open();
            command.CommandText = "CALL spaltStatusDeliv(@idDel, @status);";
                command.Parameters.Add("@idDel", MySqlDbType.Int64).Value = idDel;
                command.Parameters.Add("@status", MySqlDbType.Int64).Value = status;
                command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}