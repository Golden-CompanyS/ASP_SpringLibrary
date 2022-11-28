using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ASP_SpringLibrary.Models
{
    public class Livro
    {
        [Display(Name = "ISBN")]
        public string ISBNLiv { get; set; }

        [Display(Name = "Título")]
        public string titLiv { get; set; }

        [Display(Name = "Título Original")]
        public string titOriLiv { get; set; }

        [Display(Name = "Sinopse")]
        public string sinopLiv { get; set; }

        [Display(Name = "Imagem")]
        public string imgLiv { get; set; }

        [Display(Name = "Prateleira")]
        public int pratLiv { get; set; }

        [Display(Name = "Nº de páginas")]
        public int numPagLiv { get; set; }

        [Display(Name = "Nº da edição")]
        public int numEdicaoLiv { get; set; }

        [Display(Name = "Ano de Publicação")]
        public int anoLiv { get; set; }

        [Display(Name = "Preço")]
        public decimal precoLiv { get; set; }

        [Display(Name = "Quantidade em estoque")]
        public int qtdLiv { get; set; }

        [Display(Name = "À venda?")]
        public bool ativoLiv { get; set; }

        [Display(Name = "Editora")]
        public Editora editLiv { get; set; }

        [Display(Name = "Autores")]
        public List<Autor> autLiv { get; set; }

        [Display(Name = "Gênero")]
        public Genero genLiv { get; set; }

        [Display(Name = "Funcionário")]
        public Funcionario funcLiv { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadLiv(Livro livro)
        {
            connection.Open();
            command.CommandText = "CALL spcadLiv(@ISBNLiv, @titLiv, @titOriLiv, @sinopLiv, @imgLiv, @pratLiv,       " +
                                  "              @numPagLiv, @numEdicaoLiv, @anoLiv, @precoLiv, @qtdLiv, @ativoLiv, " +
                                  "              @idEdit, @idGen, @idFunc);                                         "; // INSERIR tbLivro
                command.Parameters.Add("@ISBNLiv", MySqlDbType.Int64).Value = livro.ISBNLiv;
                command.Parameters.Add("@titLiv", MySqlDbType.String).Value = livro.titLiv;
                command.Parameters.Add("@titOriLiv", MySqlDbType.String).Value = livro.titOriLiv;
                command.Parameters.Add("@sinopLiv", MySqlDbType.String).Value = livro.sinopLiv;
                command.Parameters.Add("@imgLiv", MySqlDbType.String).Value = livro.imgLiv;
                command.Parameters.Add("@pratLiv", MySqlDbType.Int64).Value = livro.pratLiv;
                command.Parameters.Add("@numPagLiv", MySqlDbType.Int64).Value = livro.numPagLiv;
                command.Parameters.Add("@numEdicaoLiv", MySqlDbType.Int64).Value = livro.numEdicaoLiv;
                command.Parameters.Add("@anoLiv", MySqlDbType.Int64).Value = livro.anoLiv;
                command.Parameters.Add("@precoLiv", MySqlDbType.Decimal).Value = livro.precoLiv;
                command.Parameters.Add("@qtdLiv", MySqlDbType.Int64).Value = livro.qtdLiv;
                command.Parameters.Add("@ativoLiv", MySqlDbType.Bit).Value = livro.ativoLiv;
                command.Parameters.Add("@idEdit", MySqlDbType.Int64).Value = livro.editLiv.idEdit; // ID da Editora
                command.Parameters.Add("@idGen", MySqlDbType.Int64).Value = livro.genLiv.idGen; // ID do Genero
                command.Parameters.Add("@idFunc", MySqlDbType.Int64).Value = livro.funcLiv.idFunc; // ID do Funcionario
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
            MySqlCommand command = new MySqlCommand();

            connection.Open();
            command.CommandText = "CALL spinsertAutLiv(@ISBNLiv, @idAut);"; // INSERIR tbLivro_Autor
                command.Parameters.Add("@ISBNLiv", MySqlDbType.Int64).Value = livro.ISBNLiv;
                command.Parameters.Add("@idAut", MySqlDbType.Int64).Value = autor.idAut;
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();
        }

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

        public List<Livro> checkAllLiv()
        {
            connection.Open();
                command.CommandText = "SELECT * FROM tbLivro;"; // SELECIONAR TUDO DA tbLivro
            command.Connection = connection;

            var readLiv = command.ExecuteReader();
            List<Livro> tempLivList = new List<Livro>();

            while (readLiv.Read())
            {
                var tempLiv = new Livro();

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

                tempLivList.Add(tempLiv);
            }

            readLiv.Close();
            connection.Close();

            return tempLivList;
        }

        public List<Livro> checkAllLivByFilter(string filter, string query = "")
        {
            filter = filter.ToLower();

            if (filter != "editora" &&
                filter != "autor" &&
                filter != "genero" &&
                filter != "titulo" &&
                filter != "lancamentos" &&
                filter != "populares" &&
                filter != "ate12reais")
            {
                throw new InvalidOperationException("Invalid filter parameter. Use \"editora\", \"autor\", \"genero\", \"titulo\", \"lancamentos\", \"populares\" or \"ate12reais\"."); ;
            }

            switch (filter)
            {
                case "editora":
                    command.CommandText = "SELECT ISBNLiv, titLiv, imgLiv, precoLiv " +
                                          "   FROM tblivro tbl                      " +
                                          "     INNER JOIN tbEditora tbe            " +
                                          "         on tbl.idEdit = tbe.idEdit      " +
                                          "   WHERE nomEdit = @query;               "; // SELECIONAR PELA EDITORA
                    break;
                case "autor":
                    command.CommandText = "SELECT tbl.ISBNLiv, titLiv, imgLiv, precoLiv " +
                                          "   FROM tblivro tbl                          " +
                                          "     INNER JOIN tblivroautor tbla            " +
                                          "         on tbl.ISBNLiv = tbla.ISBNLiv       " +
                                          "     INNER JOIN tbautor tba                  " +
                                          "         on tbla.idAut = tba.idAut           " +
                                          "   WHERE tba.nomAut = @query;                "; // SELECIONAR PELO AUTOR
                    break;
                case "genero":
                    command.CommandText = "SELECT ISBNLiv, titLiv, imgLiv, precoLiv " +
                                          "   FROM tblivro tbl                      " +
                                          "     INNER JOIN tbGenero tbg             " +
                                          "         on tbl.idGen = tbg.idGen        " +
                                          "   WHERE nomGen = @query;                "; // SELECIONAR PELO GENERO
                    break;
                case "titulo":
                    command.CommandText = "SELECT ISBNLiv, titLiv, imgLiv, precoLiv         " +
                                          "   FROM tblivro                                  " +
                                          "   WHERE titLiv LIKE concat('%', @query, '%') or " +
                                          "         titOriLiv LIKE concat('%', @query, '%');"; // SELECIONAR PELO TITULO
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
                                          "   WHERE precoLiv <= 12;          "; // Livros de até R$12,00
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
            command.CommandText = "SELECT nomAut, lvaut.idAut FROM tbAutor aut                              " +
                                  "   INNER JOIN tbLivroAutor lvaut on aut.idAut = lvaut.idAut " +
                                  " WHERE ISBNLiv = ?ISBNLiv;                                  "; // SELECIONAR Autores de determinado Livro
                command.Parameters.Add("?ISBNLiv", MySqlDbType.VarChar).Value = ISBNLiv;
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
    }
}