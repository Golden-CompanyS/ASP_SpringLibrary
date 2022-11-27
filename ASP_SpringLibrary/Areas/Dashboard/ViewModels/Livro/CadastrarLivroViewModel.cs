using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Autor;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Editora;
using ASP_SpringLibrary.Areas.Dashboard.ViewModels.Genero;
using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ASP_SpringLibrary.Areas.Dashboard.ViewModels.Livro
{
    public class CadastrarLivroViewModel
    {
        [Display(Name = "ISBN")]
        [RegularExpression(@"^[0-9]{10}$|^[0-9]{13}$", ErrorMessage = "O ISBN deve ter 10 ou 13 dígitos")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string ISBNLiv { get; set; }

        [Display(Name = "Título")]
        [MaxLength(100, ErrorMessage = "O título do livro deve ter até 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string titLiv { get; set; }

        [Display(Name = "Original")]
        [MaxLength(100, ErrorMessage = "O título do livro deve ter até 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string titOriLiv { get; set; }

        [Display(Name = "Sinopse")]
        [MaxLength(1500, ErrorMessage = "A sinopse deve ter até 1500 caracteres")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string sinopLiv { get; set; }

        [Display(Name = "Capa")]
        public string imgLiv { get; set; }

        [Display(Name = "Prateleira")]
        [Range(1, 50, ErrorMessage = "A numeração das prateleiras está entre 1 e 50")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int pratLiv { get; set; }

        [Display(Name = "Nº de páginas")]
        [Range(10, 10000, ErrorMessage = "O número de páginas deve estar entre 10 e 10.000")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int numPagLiv { get; set; }

        [Display(Name = "Nº da edição")]
        [Range(1, 500, ErrorMessage = "A edição do livro deve estar entre 1 e 500")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int numEdicaoLiv { get; set; }

        [Display(Name = "Ano de Publicação")]
        [Range(1000, 9999, ErrorMessage = "Ano inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int anoLiv { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal precoLiv { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "a quantidade no estoque não pode ser negativa")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int qtdLiv { get; set; }

        [Display(Name = "Em venda?")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool ativoLiv { get; set; }

        [Display(Name = "Editora")]
        public EditoraDropDownViewModel editLiv { get; set; }

        [Display(Name = "Gênero")]
        public GeneroDropDownViewModel genLiv { get; set; }

        [Display(Name = "Autores")]
        public List<AutorDropDownViewModel> autLiv { get; set; }

        public int funcIdLiv { get; set; }
    }
}