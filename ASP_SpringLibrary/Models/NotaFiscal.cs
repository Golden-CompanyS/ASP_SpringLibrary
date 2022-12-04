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
    public class NotaFiscal
    {
        public int idNF { get; set; }

        [Display(Name = "Data e hora de emissão")]
        public DateTime dateNF { get; set; }

        [Display(Name = "Pagamento")]
        [Required(ErrorMessage = "Especifique a forma de pagamento.")]
        public string pagNF { get; set; }

        [Display(Name = "Total da compra")]
        public decimal valNF { get; set; }

        [Display(Name = "É delivery?")]
        public bool isDelivNF { get; set; }
        public List<Livro> livrosNF { get; set; }
        public Delivery deliveryNF { get; set; }
        public Cliente clienteNF { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void sellNF(NotaFiscal notaFiscal)
        {
            connection.Open();
            command.CommandText = "CALL spcomecVenda(@pagNF, @idCli, @isDeliv, @dtPrevDel);";
                command.Parameters.Add("@pagNF", MySqlDbType.VarChar).Value = notaFiscal.pagNF;
                command.Parameters.Add("@idCli", MySqlDbType.Int64).Value = notaFiscal.clienteNF.idCli;
                command.Parameters.Add("@isDeliv", MySqlDbType.Bit).Value = notaFiscal.isDelivNF;
                command.Parameters.Add("@dtPrevDel", MySqlDbType.DateTime).Value = notaFiscal.deliveryNF.dtPrevDel;
                command.Connection = connection;
            command.ExecuteNonQuery();

            foreach(var livro in notaFiscal.livrosNF)
            {
                addProd(notaFiscal.idNF, livro.ISBNLiv, livro.qtdLiv);
            }
        }

        public void addProd(int idNF, string ISBNLiv, int qtdLiv)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            MySqlCommand command = new MySqlCommand();

            connection.Open();
            command.CommandText = "CALL spputLivVenda((select idVen from tbVenda order by idVen desc limit 1), @ISBNLiv, @qtdLiv);";
                command.Parameters.Add("@ISBNLiv", MySqlDbType.VarChar).Value = ISBNLiv;
                command.Parameters.Add("@qtdLiv", MySqlDbType.Int64).Value = qtdLiv;
                command.Connection = connection;
            command.ExecuteNonQuery();
        }

        public NotaFiscal checkNFById(int idNF)
        {
            connection.Open();
            command.CommandText = "SELECT tbVenda.idVen, dtHoraVen, tbCliente.idCli, tipoPgtVen, valTotVen, " +
                                  "     delivVen, statDel, dtPrevDel, dtFinDel FROM tbVenda                          " +
                                  "     LEFT JOIN tbCliente on tbVenda.idCli = tbCliente.idCli             " +
                                  "     LEFT JOIN tbDelivery on tbVenda.idVen = tbDelivery.idVen           " +
                                  "  WHERE tbVenda.idVen = @idNF;";
                command.Parameters.Add("@idNF", MySqlDbType.Int64).Value = idNF;
                command.Connection = connection;

            var readNF = command.ExecuteReader();
            var tempNF = new NotaFiscal();

            if (readNF.Read())
            {
                tempNF.idNF = int.Parse(readNF["idVen"].ToString());
                tempNF.dateNF = DateTime.Parse(readNF["dtHoraVen"].ToString());
                tempNF.pagNF = readNF["tipoPgtVen"].ToString();
                tempNF.valNF = decimal.Parse(readNF["valTotVen"].ToString());
                tempNF.isDelivNF = bool.Parse(readNF["delivVen"].ToString());
                tempNF.clienteNF = new Cliente().checkCliById(int.Parse(readNF["idCli"].ToString()));
                    if (tempNF.isDelivNF)
                {
                    tempNF.deliveryNF = new Delivery();
                    tempNF.deliveryNF.dtPrevDel = DateTime.Parse(readNF["dtPrevDel"].ToString());
                    tempNF.deliveryNF.statDel = char.Parse(readNF["statDel"].ToString());
                    if (tempNF.deliveryNF.statDel == '2')
                    {
                        tempNF.deliveryNF.dtEntDel = DateTime.Parse(readNF["dtFinDel"].ToString());
                    }
                }
            }

            readNF.Close();
            connection.Close();

            return tempNF;
        }

        public int getLastNotafiscal()
        {
            connection.Open();
            command.CommandText = "SELECT idVen FROM tbVenda ORDER BY idVen DESC LIMIT 1;";
                command.Connection = connection;
            var lastNFId = (int) command.ExecuteScalar();
            connection.Close();

            return lastNFId;
        }

        public List<NotaFiscal> checkAllNf()
        {
            connection.Open();
            command.CommandText = " SELECT tbVenda.idVen, dtHoraVen, tbCliente.NomCli, " +
                                  "  tipoPgtVen, valTotVen, delivVen, idDel, statDel,  " +
                                  "  dtPrevDel, dtFinDel                               " +
                                  "     FROM tbVenda                                   " +
                                  "         INNER JOIN tbCliente                       " +
                                  "             on tbVenda.idCli = tbCliente.idCli     " +
                                  "         LEFT JOIN tbDelivery                       " +
                                  "             on tbVenda.idVen = tbDelivery.idVen;   "; // SELECIONAR TUDO DA tbVenda + Cliente
                command.Connection = connection;

            var readNf = command.ExecuteReader();
            List<NotaFiscal> tempNfList = new List<NotaFiscal>();

            while (readNf.Read())
            {
                var tempNf = new NotaFiscal();

                tempNf.idNF = int.Parse(readNf["idVen"].ToString());
                tempNf.dateNF = DateTime.Parse(readNf["dtHoraVen"].ToString());
                tempNf.clienteNF = new Cliente() { nomCli = readNf["nomCli"].ToString() };
                tempNf.pagNF = readNf["tipoPgtVen"].ToString();
                tempNf.valNF = decimal.Parse(readNf["valTotVen"].ToString());
                tempNf.isDelivNF = readNf["delivVen"].ToString().AsBool();

                if (tempNf.isDelivNF)
                {
                    var tempDel = new Delivery();
                        tempDel.idDel = int.Parse(readNf["idDel"].ToString());
                        tempDel.statDel = char.Parse(readNf["statDel"].ToString());
                        tempDel.dtPrevDel = DateTime.Parse(readNf["dtPrevDel"].ToString());

                    if (readNf["dtFinDel"].ToString() != "")
                    {
                        tempDel.dtEntDel = DateTime.Parse(readNf["dtFinDel"].ToString());
                    }

                    tempNf.deliveryNF = tempDel;
                }

                tempNfList.Add(tempNf);
            }

            readNf.Close();
            connection.Close();

            return tempNfList;
        }
    }
}