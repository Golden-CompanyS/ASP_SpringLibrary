using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace ASP_SpringLibrary.ViewModels.Cliente
{
    public class CadastroClienteViewModel
    {
        // Cliente
        public int idCli { get; set; }

        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Informe seu nome")]
        public string nomCli { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe seu email")]
        [Remote("EmailExists", "Cliente", AdditionalFields = "idCli", ErrorMessage = "E-mail já cadastrado!")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string emailCli { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        public string senhaCli { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [CompareAttribute(nameof(senhaCli), ErrorMessage = "As senhas são diferentes")]
        public string confSenhaCli { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Informe seu celular")]
        [RegularExpression(@"^[1-9]{2} (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Formato: xx xxxxx-xxxx")]
        public string celCli { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Informe seu CEP")]
        [RegularExpression(@"^[0-9]{5}\-[0-9]{3}$", ErrorMessage = "Formato: 00000-000")]
        public string CEPCli { get; set; }

        [Display(Name = "Nº")]
        [Required(ErrorMessage = "Informe seu nº de endereço")]
        public int numEndCli { get; set; }

        [Display(Name = "Complemento")]
        public string compEndCli { get; set; }

        [Display(Name = "Natureza")]
        [Required(ErrorMessage = "Informe sua natureza")]
        public bool tipoCli { get; set; } // false == fisico | true == juridico

        // ClienteFisico
        [Display(Name = "CPF")]
        [Remote("CliFExists", "Cliente", AdditionalFields = "idCli", ErrorMessage = "CPF já cadastrado!")]
        [RegularExpression(@"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}$", ErrorMessage = "Formato: 000.000.000-00")]
        public string CPFCliF { get; set; }

        [Display(Name = "Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtNascCliF { get; set; }

        // ClienteJuridico
        [Display(Name = "CPNJ")]
        [Remote("CliJExists", "Cliente", AdditionalFields = "idCli", ErrorMessage = "CNPJ já cadastrado!")]
        [RegularExpression(@"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$", ErrorMessage = "Formato: 00.000.000/0000-00")]
        public string CNPJCliJ { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string fantaCliJ { get; set; }

        [Display(Name = "Representante")]
        public string represCliJ { get; set; }
    }
}