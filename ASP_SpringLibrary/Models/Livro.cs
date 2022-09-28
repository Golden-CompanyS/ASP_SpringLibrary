using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Livro
    {
        public int idLiv { get; set; }
        public int ISBNLiv { get; set; }
        public string sinopLiv { get; set; }
        public string nomOriLiv { get; set; }
        public int pratLiv { get; set; }
        public int publLiv { get; set; }
        public int pagLiv { get; set; }
        public int anoLiv { get; set; }
        public Editora editLiv { get; set; }
        public List<Autor> autLiv { get; set; }
        public Genero genLiv { get; set; }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void cadLiv(Livro livro)
        {
            connection.Open();
            command.CommandText = "CALL spcadLiv(@ISBNLiv, @sinopLiv, @nomOriLiv, @pratLiv, " +
                                  "              @publLiv, @pagLiv, @anoLiv,                " +
                                  "              @FKeditLiv, @FKgenLiv);                    "; // INSERIR tbLivro
                command.Parameters.Add("@ISBNLiv", MySqlDbType.Int64).Value = livro.ISBNLiv;
                command.Parameters.Add("@sinopLiv", MySqlDbType.String).Value = livro.sinopLiv;
                command.Parameters.Add("@nomOriLiv", MySqlDbType.String).Value = livro.nomOriLiv;
                command.Parameters.Add("@pratLiv", MySqlDbType.Int64).Value = livro.pratLiv;
                command.Parameters.Add("@publLiv", MySqlDbType.Int64).Value = livro.publLiv;
                command.Parameters.Add("@pagLiv", MySqlDbType.Int64).Value = livro.pagLiv;
                command.Parameters.Add("@anoLiv", MySqlDbType.Int64).Value = livro.anoLiv;
                command.Parameters.Add("@FKeditLiv", MySqlDbType.Int64).Value = livro.editLiv.idEdit; // FOREIGN KEY DA tbEditora
                command.Parameters.Add("@FKgenLiv", MySqlDbType.Int64).Value = livro.genLiv.idGen; // FOREIGN KEY DA tbGenero
                command.Connection = connection;
                command.ExecuteNonQuery();
            connection.Close();

            foreach (Autor autor in livro.autLiv)
            {
                new Autor().cadAut(autor); // INSERIR tbAutor
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
        }

        public Livro checkLivById(int idLiv)
        {
            connection.Open();
            command.CommandText = "CALL spcheckLivById(@idLiv);"; // SELECIONAR tbLivro PELO ID
            command.Parameters.Add("@idLiv", MySqlDbType.Int64).Value = idLiv;
            command.Connection = connection;

            var readLiv = command.ExecuteReader();
            var tempLiv = new Livro();

            if (readLiv.Read())
            {
                tempLiv.idLiv = int.Parse(readLiv["idLiv"].ToString());
                tempLiv.ISBNLiv = int.Parse(readLiv["ISBNLiv"].ToString());
                tempLiv.sinopLiv = readLiv["sinopLiv"].ToString();
                tempLiv.nomOriLiv = readLiv["nomOriLiv"].ToString();
                tempLiv.pratLiv = int.Parse(readLiv["pratLiv"].ToString());
                tempLiv.publLiv = int.Parse(readLiv["publLiv"].ToString());
                tempLiv.pagLiv = int.Parse(readLiv["pagLiv"].ToString());
                tempLiv.anoLiv = int.Parse(readLiv["anoLiv"].ToString());
                tempLiv.editLiv = new Editora().checkEditById(int.Parse(readLiv["editLiv"].ToString()));
                tempLiv.autLiv = new Autor().checkAutListByLivId(int.Parse(readLiv["idLiv"].ToString()));
                tempLiv.genLiv = new Genero().checkGenById(int.Parse(readLiv["genLiv"].ToString()));
            }

            readLiv.Close();
            connection.Close();

            return tempLiv;
        }

        // FALTAM UM MONTE DE MÉTODOS.
        // REVER SE DEVEM ESTAR AQUI OU NA CLASSE PRODUTO.
    }
}