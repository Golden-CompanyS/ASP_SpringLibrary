using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    public class LivroController : Controller
    {
        // GET: Dashboard/Livro
        public ActionResult Index()
        {
            var tempLivList = new Livro().checkAllLiv();

            return View(tempLivList);
        }

        /*[HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Alterar(string ISBNLiv)
        {
            var tempLiv = new Livro().checkLivByISBN(ISBNLiv);

            return View(tempFunc);
        }*/
    }
}