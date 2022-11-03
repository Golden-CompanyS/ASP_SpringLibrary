using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Livro
    {
        [Display(Name = "ISBN")]
        public string ISBNLiv { get; set; }

        [Display(Name = "Título")]
        public string titLiv { get; set; }

        [Display(Name = "Original")]
        public string titOriLiv { get; set; }

        [Display(Name = "Sinopse")]
        public string sinopLiv { get; set; }

        public string imgLiv { get; set; }

        [Display(Name = "Prateleira")]
        public int pratLiv { get; set; }

        [Display(Name = "Nº de páginas")]
        public int numPagLiv { get; set; }

        [Display(Name = "Nº da edição")]
        public int numEdicaoLiv { get; set; }

        [Display(Name = "Publicação")]
        public int anoLiv { get; set; }

        [Display(Name = "Preço")]
        public decimal precoLiv { get; set; }

        [Display(Name = "Quantidade em estoque")]
        public int qtdLiv { get; set; }

        [Display(Name = "Em venda?")]
        public bool ativoLiv { get; set; }
        public Editora editLiv { get; set; }
        public List<Autor> autLiv { get; set; }
        public Genero genLiv { get; set; }
        public Funcionario funcLiv { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        /*public void cadLivIfNotExists(Livro livro)
        {
            connection.Open();
            command.CommandText = "CALL spcadLiv(@ISBNLiv, @sinopLiv, @titLiv, @titOriLiv, " +
                                  "              @pratLiv, @publLiv, @pagLiv, @anoLiv,     " +
                                  "              @FKeditLiv, @FKgenLiv);                   "; // INSERIR tbLivro
                command.Parameters.Add("@ISBNLiv", MySqlDbType.Int64).Value = livro.ISBNLiv;
                command.Parameters.Add("@sinopLiv", MySqlDbType.String).Value = livro.sinopLiv;
                command.Parameters.Add("@titLiv", MySqlDbType.String).Value = livro.titLiv;
                command.Parameters.Add("@titOriLiv", MySqlDbType.String).Value = livro.titOriLiv;
                command.Parameters.Add("@pratLiv", MySqlDbType.Int64).Value = livro.pratLiv;
                command.Parameters.Add("@publLiv", MySqlDbType.Int64).Value = livro.publLiv;
                command.Parameters.Add("@pagLiv", MySqlDbType.Int64).Value = livro.pagLiv;
                command.Parameters.Add("@anoLiv", MySqlDbType.Int64).Value = livro.anoLiv;
                command.Parameters.Add("@FKeditLiv", MySqlDbType.Int64).Value = livro.editLiv.idEdit; // ID da Editora
                command.Parameters.Add("@FKgenLiv", MySqlDbType.Int64).Value = livro.genLiv.idGen; // ID do Genero
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();

            foreach (Autor autor in livro.autLiv)
            {
                cadAutLiv(autor, livro); // INSERIR tbLivro_Autor
            }
        }

        public void cadAutLiv(Autor autor, Livro livro)
        {
            connection.Open();
            command.CommandText = "CALL spcadAutLiv(@idAut, @idLiv);"; // INSERIR tbLivro_Autor
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = autor.idAut;
                command.Parameters.Add("@idLiv", MySqlDbType.Int64).Value = livro.idLiv;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }*/

        public Livro checkLivByISBN(string ISBNLiv)
        {
            connection.Open();
            command.CommandText = "SELECT ISBNLiv, titLiv, titOriLiv, sinopLiv, imgLiv, pratLiv, numPagLiv, " +
                                  "       numEdicaoLiv, anoLiv, precoLiv, qtdLiv, ativoLiv, nomEdit, nomGen " +
                                  "     FROM tbLivro liv                                                    " +
                                  "     INNER JOIN tbEditora edt on liv.idEdit = edt.idEdit                 " +
                                  "     INNER JOIN tbGenero gen on liv.idGen = gen.idGen                    " +
                                  "   WHERE ISBNLiv = @ISBNLiv;                                             "; // SELECIONAR tbLivro PELO ISBN
                command.Parameters.Add("@ISBNLiv", MySqlDbType.VarChar).Value = ISBNLiv;
            command.Connection = connection;

            var readLiv = command.ExecuteReader();
            var tempLiv = new Livro();

            if (readLiv.Read())
            {
                tempLiv.ISBNLiv = readLiv["ISBNLiv"].ToString();
                tempLiv.titLiv = readLiv["titLiv"].ToString();
                tempLiv.titOriLiv = readLiv["titOriLiv"].ToString();
                tempLiv.sinopLiv = readLiv["sinopLiv"].ToString();
                tempLiv.imgLiv = readLiv["imgLiv"].ToString();
                tempLiv.pratLiv = int.Parse(readLiv["pratLiv"].ToString());
                tempLiv.numPagLiv = int.Parse(readLiv["numPagLiv"].ToString());
                tempLiv.numEdicaoLiv = int.Parse(readLiv["numEdicaoLiv"].ToString());
                tempLiv.anoLiv = int.Parse(readLiv["anoLiv"].ToString());
                tempLiv.precoLiv = decimal.Parse(readLiv["precoLiv"].ToString());
                tempLiv.qtdLiv = int.Parse(readLiv["qtdLiv"].ToString());
                tempLiv.ativoLiv = bool.Parse(readLiv["ativoLiv"].ToString());
                tempLiv.editLiv = new Editora() { nomEdit = readLiv["nomEdit"].ToString() };
                tempLiv.genLiv = new Genero() { nomGen = readLiv["nomGen"].ToString() };
            }

            readLiv.Close();
            connection.Close();

            tempLiv.autLiv = checkAutListByLivISBN(tempLiv.ISBNLiv);

            return tempLiv;
        }

        /*public List<Livro> checkAllLiv()
        {
            connection.Open();
                command.CommandText = "CALL spcheckAllLiv();"; // SELECIONAR TUDO DA tbLivro
            command.Connection = connection;

            var readLiv = command.ExecuteReader();
            List<Livro> tempLivList = new List<Livro>();

            while (readLiv.Read())
            {
                var tempLiv = new Livro();

                tempLiv.idLiv = int.Parse(readLiv["idLiv"].ToString());
                tempLiv.ISBNLiv = int.Parse(readLiv["ISBNLiv"].ToString());
                tempLiv.sinopLiv = readLiv["sinopLiv"].ToString();
                tempLiv.titLiv = readLiv["titLiv"].ToString();
                tempLiv.titOriLiv = readLiv["titOriLiv"].ToString();
                tempLiv.pratLiv = int.Parse(readLiv["pratLiv"].ToString());
                tempLiv.publLiv = int.Parse(readLiv["publLiv"].ToString());
                tempLiv.pagLiv = int.Parse(readLiv["pagLiv"].ToString());
                tempLiv.anoLiv = int.Parse(readLiv["anoLiv"].ToString());
                tempLiv.editLiv = new Editora().checkEditById(int.Parse(readLiv["editLiv"].ToString()));
                tempLiv.autLiv = checkAutListByLivId(int.Parse(readLiv["idLiv"].ToString()));
                tempLiv.genLiv = new Genero().checkGenById(int.Parse(readLiv["genLiv"].ToString()));

                tempLivList.Add(tempLiv);
            }

            readLiv.Close();
            connection.Close();

            return tempLivList;
        }*/

        public List<Livro> checkAllLivByFilter(string filter, string query = "")
        {
            filter = filter.ToLower();

            if (filter != "editora" &&
                filter != "autor" &&
                filter != "genero" &&
                filter != "lancamentos" &&
                filter != "populares" &&
                filter != "ate12reais")
            {
                throw new InvalidOperationException("Invalid filter parameter. Use \"editora\", \"autor\", \"genero\", \"lancamentos\", \"populares\" or \"ate12reais\"."); ;
            }

            switch (filter)
            {
                case "editora":
                    command.CommandText = "CALL spcheckAllLivByEdit(@query);"; // SELECIONAR PELA EDITORA
                    break;
                case "autor":
                    command.CommandText = "CALL spcheckAllLivByAut(@query);"; // SELECIONAR PELO AUTOR
                    break;
                case "genero":
                    command.CommandText = "CALL spcheckAllLivByGen(@query);"; // SELECIONAR PELO GENERO
                    break;
                case "lancamentos":
                    command.CommandText = "SELECT ISBNLiv, titLiv, imgLiv, precoLiv FROM tbLivro            " +
                                          "   WHERE anoLiv = " + DateTime.Now.Year + " and ativoLiv = true; "; // Livros lançados esse ano
                    break;
                case "populares":
                    command.CommandText = ""; // Livros mais vendidos
                    break;
                case "ate12reais":
                    command.CommandText = "SELECT ISBNLiv, titLiv, imgLiv, precoLiv FROM tbLivro " +
                                          "  ;          "; // Livros de até R$12,00
                    break;
            }

            command.Parameters.Add("@query", MySqlDbType.VarChar).Value = query;
                connection.Open();
                command.Connection = connection;

            var readLiv = command.ExecuteReader();
            List<Livro> tempLivList = new List<Livro>();

            while (readLiv.Read())
            {
                var tempLiv = new Livro();

                tempLiv.ISBNLiv = readLiv["ISBNLiv"].ToString();
                tempLiv.titLiv = readLiv["titLiv"].ToString();
                tempLiv.imgLiv = readLiv["imgLiv"].ToString();
                tempLiv.precoLiv = decimal.Parse(readLiv["precoLiv"].ToString());

                tempLivList.Add(tempLiv);
            }

            readLiv.Close();
            connection.Close();

            return tempLivList;
        }

        /*public void altLiv(Livro livro)
        {
            connection.Open();
            command.CommandText = "CALL spaltLiv(@idLiv, @ISBNLiv, @sinopLiv, @titLiv, @titOriLiv, " +
                                  "              @pratLiv, @publLiv, @pagLiv, @anoLiv,             " +
                                  "              @FKeditLiv, @FKgenLiv);                           "; // ALTERAR tbLivro
                command.Parameters.Add("@idLiv", MySqlDbType.Int64).Value = livro.idLiv;
                command.Parameters.Add("@ISBNLiv", MySqlDbType.Int64).Value = livro.ISBNLiv;
                command.Parameters.Add("@sinopLiv", MySqlDbType.String).Value = livro.sinopLiv;
                command.Parameters.Add("@titLiv", MySqlDbType.String).Value = livro.titLiv;
                command.Parameters.Add("@titOriLiv", MySqlDbType.String).Value = livro.titOriLiv;
                command.Parameters.Add("@pratLiv", MySqlDbType.Int64).Value = livro.pratLiv;
                command.Parameters.Add("@publLiv", MySqlDbType.Int64).Value = livro.publLiv;
                command.Parameters.Add("@pagLiv", MySqlDbType.Int64).Value = livro.pagLiv;
                command.Parameters.Add("@anoLiv", MySqlDbType.Int64).Value = livro.anoLiv;
                command.Parameters.Add("@FKeditLiv", MySqlDbType.Int64).Value = livro.editLiv.idEdit; // FOREIGN KEY DA tbEditora
                command.Parameters.Add("@FKgenLiv", MySqlDbType.Int64).Value = livro.genLiv.idGen; // FOREIGN KEY DA tbGenero
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();

            delAutsLivByLivId(livro.idLiv); // TIRAR TODOS RELACIONADOS PARA ADICIONAR TUDO NOVAMENTE

            foreach (Autor autor in livro.autLiv)
            {
                cadAutLiv(autor, livro);
            }
        }

        public void delAutsLivByLivId(int idLiv)
        {
            connection.Open();
            command.CommandText = "CALL spdelAutsLivByLivId(@idLiv);"; // DELETAR TODAS RELAÇÕES DE AUTORES COM O LIVRO EM ESPECÍFICO
                command.Parameters.Add("@idLiv", MySqlDbType.Int64).Value = idLiv;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }*/

        public List<Autor> checkAutListByLivISBN(string ISBNLiv)
        {
            connection.Open();
            command.CommandText = "SELECT nomAut FROM tbAutor aut                              " +
                                  "   INNER JOIN tbLivroAutor lvaut on aut.idAut = lvaut.idAut " +
                                  " WHERE ISBNLiv = ?ISBNLiv;                                  "; // SELECIONAR Autores de determinado Livro
                command.Parameters.Add("?ISBNLiv", MySqlDbType.VarChar).Value = ISBNLiv;
                command.Connection = connection;

            var readAut = command.ExecuteReader();
            List<Autor> tempAutList = new List<Autor>();

            while (readAut.Read())
            {
                var tempAut = new Autor();

                tempAut.nomAut = readAut["nomAut"].ToString();

                tempAutList.Add(tempAut);
            }

            readAut.Close();
            connection.Close();

            return tempAutList;
        }
    }
}