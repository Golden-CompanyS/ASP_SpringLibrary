using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.ViewModels.Cliente
{
    public class LoginClienteViewModel
    {
        public string urlRetorno { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe seu email")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string emailCli { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        public string senhaCli { get; set; }
    }
}