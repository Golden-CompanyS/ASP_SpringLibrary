using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Delivery
    {
        [Display(Name = "Previsão de Entrega")]
        public DateTime dtPrevDel { get; set; }

        [Display(Name = "Data Entregue")]
        public DateTime? dtEntDel { get; set; }
        public char statDel { get; set; }
    }
}