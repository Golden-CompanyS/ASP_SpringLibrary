using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.ViewModels.Livro
{
    public class LivrosHomeViewModel
    {
        public string ISBNLiv { get; set; }
        public string titLiv { get; set; }
        public string imgLiv { get; set; }
        public decimal precoLiv { get; set; }
    }
}