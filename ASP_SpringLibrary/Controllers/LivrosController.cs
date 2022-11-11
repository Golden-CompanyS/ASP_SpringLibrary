using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livros
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detalhes(string ISBNLiv)
        {
            if (ISBNLiv == null || ISBNLiv == "")
            {
                return RedirectToAction("Index");
            }

            var tempLiv = new Livro().checkLivByISBN(ISBNLiv);

            return View(tempLiv);
        }
    }
}