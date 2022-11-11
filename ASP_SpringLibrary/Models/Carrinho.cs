using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Carrinho
    {
        public Livro livroCart { get; set; }
        public int qtdProdCart { get; set; }
    }
}