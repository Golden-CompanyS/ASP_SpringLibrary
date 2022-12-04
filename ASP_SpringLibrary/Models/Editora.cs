using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ASP_SpringLibrary.Models
{
    public class Editora
    {
        public int idEdit { get; set; }

        [Display(Name = "Editora")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O nome da editora deve ter até 30 caracteres")]
        [Remote("EditExists", "Editora", "Dashboard", AdditionalFields = "idEdit", ErrorMessage = "A editora já existe!")]
        public string nomEdit { get; set; }

        [Display(Name = "Celular de Contato")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[1-9]{2} (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Formato: xx xxxxx-xxxx")]
        public string celEdit { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O email da editora deve ter até 50 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string emailEdit { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadEdit(Editora editora)
        {
            connection.Open();
            command.CommandText = "CALL spcadEdit(@nomEdit, @celEdit, @emailEdit);"; // INSERIR tbEditora
                command.Parameters.Add("@nomEdit", MySqlDbType.VarChar).Value = editora.nomEdit;
                command.Parameters.Add("@celEdit", MySqlDbType.VarChar).Value = editora.celEdit;
                command.Parameters.Add("@emailEdit", MySqlDbType.VarChar).Value = editora.emailEdit;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public bool editExists(int idEdit, string nomEdit)
        {
            connection.Open();
            command.CommandText = "SELECT nomEdit FROM tbEditora WHERE idEdit != @idEdit and nomEdit = @nomEdit;";
                command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = idEdit;
                command.Parameters.Add("@nomEdit", MySqlDbType.VarChar).Value = nomEdit;
                command.Connection = connection;
            string edit = (string) command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (edit.IsNullOrWhiteSpace())
                return false;
            else
                return true;
        }

        public void altEdit(Editora editora)
        {
            connection.Open();
            command.CommandText = "CALL spaltEdit(@idEdit, @nomEdit, @celEdit, @emailEdit);"; // ALTERAR tbEditora
                command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = editora.idEdit;
                command.Parameters.Add("@nomEdit", MySqlDbType.VarChar).Value = editora.nomEdit;
                command.Parameters.Add("@celEdit", MySqlDbType.VarChar).Value = editora.celEdit;
                command.Parameters.Add("@emailEdit", MySqlDbType.VarChar).Value = editora.emailEdit;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Editora> checkAllEdit()
        {
            connection.Open();
            command.CommandText = "CALL spcheckAllEdit();"; // SELECIONAR TUDO DA tbEditora
                command.Connection = connection;

            var readEdit = command.ExecuteReader();
            List<Editora> tempEditList = new List<Editora>();

            while (readEdit.Read())
            {
                var tempEdit = new Editora();

                tempEdit.idEdit = int.Parse(readEdit["idEdit"].ToString());
                tempEdit.nomEdit = readEdit["nomEdit"].ToString();
                tempEdit.celEdit = readEdit["celEdit"].ToString();
                tempEdit.emailEdit = readEdit["emailEdit"].ToString();

                tempEditList.Add(tempEdit);
            }

            readEdit.Close();
            connection.Close();

            return tempEditList;
        }

        public Editora checkEditById(int idEdit)
        {
            connection.Open();
            command.CommandText = "CALL spcheckEditById(@idEdit);"; // SELECIONAR tbEditora PELO ID
                command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = idEdit;
                command.Connection = connection;

            var readEdit = command.ExecuteReader();
            var tempEdit = new Editora();

            if (readEdit.Read())
            {
                tempEdit.idEdit = int.Parse(readEdit["idEdit"].ToString());
                tempEdit.nomEdit = readEdit["nomEdit"].ToString();
                tempEdit.celEdit = readEdit["celEdit"].ToString();
                tempEdit.emailEdit = readEdit["emailEdit"].ToString();
            }

            readEdit.Close();
            connection.Close();

            return tempEdit;
        }
    }
}