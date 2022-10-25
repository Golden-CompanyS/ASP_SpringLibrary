using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ASP_SpringLibrary.Models
{
    public class Funcionario
    {
        public int idFunc { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do(a) funcionário(a) deve ter até 100 caracteres")]
        public string nomFunc { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Remote("FuncExists", "Funcionario", "Dashboard", AdditionalFields = "idFunc", ErrorMessage = "O(a) funcionário(a) já existe!")]
        [RegularExpression(@"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}$", ErrorMessage = "Formato: 000.000.000-00")]
        public string CPFFunc { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string imgFunc { get; set; }

        [Display(Name = "Celular de Contato")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[1-9]{2} (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Formato: xx xxxxx-xxxx")]
        public string celFunc { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "O cargo do(a) funcionário(a) deve ter até 30 caracteres")]
        public string cargoFunc { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O email do funcionário(a) deve ter até 30 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string emailFunc { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        public string senhaFunc { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadFunc(Funcionario funcionario)
        {
            connection.Open();
            command.CommandText = "CALL spcadFunc(@nomFunc, @CPFFunc, @imgFunc, @celFunc, @cargoFunc, @emailFunc, @senhaFunc);"; // INSERIR tbFuncionario
                command.Parameters.Add("@nomFunc", MySqlDbType.VarChar).Value = funcionario.nomFunc;
                command.Parameters.Add("@CPFFunc", MySqlDbType.VarChar).Value = funcionario.CPFFunc;
                command.Parameters.Add("@imgFunc", MySqlDbType.VarChar).Value = funcionario.imgFunc;
                command.Parameters.Add("@celFunc", MySqlDbType.VarChar).Value = funcionario.celFunc;
                command.Parameters.Add("@cargoFunc", MySqlDbType.VarChar).Value = funcionario.cargoFunc;
                command.Parameters.Add("@emailFunc", MySqlDbType.VarChar).Value = funcionario.emailFunc;
                command.Parameters.Add("@senhaFunc", MySqlDbType.VarChar).Value = funcionario.senhaFunc;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public bool funcExists(int idFunc, string CPFFunc)
        {
            connection.Open();
            command.CommandText = "SELECT CPFFunc FROM tbFuncionario WHERE idFunc != @idFunc and CPFFunc = @CPFFunc;";
                command.Parameters.Add("@idFunc", MySqlDbType.Int64).Value = idFunc;
                command.Parameters.Add("@CPFFunc", MySqlDbType.VarChar).Value = CPFFunc;
                command.Connection = connection;
            string edit = (string)command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            connection.Close();

            if (edit.IsNullOrWhiteSpace())
                return false;
            else
                return true;
        }

        public void altFunc(Funcionario funcionario)
        {
            connection.Open();
            command.CommandText = "CALL spaltFunc(@idFunc, @nomFunc, @CPFFunc, @imgFunc, @celFunc, @cargoFunc, @emailFunc, @senhaFunc);"; // ALTERAR tbFuncionario
                command.Parameters.Add("@idFunc", MySqlDbType.Int64).Value = funcionario.idFunc;
                command.Parameters.Add("@nomFunc", MySqlDbType.VarChar).Value = funcionario.nomFunc;
                command.Parameters.Add("@CPFFunc", MySqlDbType.VarChar).Value = funcionario.CPFFunc;
                command.Parameters.Add("@imgFunc", MySqlDbType.VarChar).Value = funcionario.imgFunc;
                command.Parameters.Add("@celFunc", MySqlDbType.VarChar).Value = funcionario.celFunc;
                command.Parameters.Add("@cargoFunc", MySqlDbType.VarChar).Value = funcionario.cargoFunc;
                command.Parameters.Add("@emailFunc", MySqlDbType.VarChar).Value = funcionario.emailFunc;
                command.Parameters.Add("@senhaFunc", MySqlDbType.VarChar).Value = funcionario.senhaFunc;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Funcionario> checkAllFunc()
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbFuncionario"; // SELECIONAR TUDO DA tbFuncionario
                command.Connection = connection;

            var readFunc = command.ExecuteReader();
            List<Funcionario> tempFuncList = new List<Funcionario>();

            while (readFunc.Read())
            {
                var tempFunc = new Funcionario();

                tempFunc.idFunc = int.Parse(readFunc["idFunc"].ToString());
                tempFunc.nomFunc = readFunc["nomFunc"].ToString();
                tempFunc.CPFFunc = readFunc["CPFFunc"].ToString();
                tempFunc.imgFunc = readFunc["imgFunc"].ToString();
                tempFunc.celFunc = readFunc["celFunc"].ToString();
                tempFunc.cargoFunc = readFunc["cargoFunc"].ToString();
                tempFunc.emailFunc = readFunc["emailFunc"].ToString();
                tempFunc.senhaFunc = readFunc["senhaFunc"].ToString();

                tempFuncList.Add(tempFunc);
            }

            readFunc.Close();
            connection.Close();

            return tempFuncList;
        }

        public Funcionario checkFuncById(int idFunc)
        {
            connection.Open();
            command.CommandText = "SELECT * FROM tbFuncionario WHERE idFunc = @idFunc;"; // SELECIONAR tbFuncionario PELO ID
                command.Parameters.Add("@idFunc", MySqlDbType.Int64).Value = idFunc;
                command.Connection = connection;

            var readFunc = command.ExecuteReader();
            var tempFunc = new Funcionario();

            if (readFunc.Read())
            {
                tempFunc.idFunc = int.Parse(readFunc["idFunc"].ToString());
                tempFunc.nomFunc = readFunc["nomFunc"].ToString();
                tempFunc.CPFFunc = readFunc["CPFFunc"].ToString();
                tempFunc.imgFunc = readFunc["imgFunc"].ToString();
                tempFunc.celFunc = readFunc["celFunc"].ToString();
                tempFunc.cargoFunc = readFunc["cargoFunc"].ToString();
                tempFunc.emailFunc = readFunc["emailFunc"].ToString();
                tempFunc.senhaFunc = readFunc["senhaFunc"].ToString();
            }

            readFunc.Close();
            connection.Close();

            return tempFunc;
        }
    }
}