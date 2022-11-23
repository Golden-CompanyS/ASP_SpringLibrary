using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.ViewModels.Livro
{
    public class CadastroLivroViewModel
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

        public string editNom { get; set; }

        public List<string> autNom { get; set; }

        public string genNom { get; set; }

        public string funcNom { get; set; }
    }
}