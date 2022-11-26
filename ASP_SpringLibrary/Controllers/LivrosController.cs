using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.ViewModels.Livro;
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
            var tempLivList = new Livro().checkAllLiv();
            var tempLivViewList = new List<LivrosHomeViewModel>();
            
            foreach(var tempLiv in tempLivList)
            {
                var tempLivView = new LivrosHomeViewModel();
                    tempLivView.ISBNLiv = tempLiv.ISBNLiv;
                    tempLivView.titLiv = tempLiv.titLiv;
                    tempLivView.imgLiv = tempLiv.imgLiv;
                    tempLivView.precoLiv = tempLiv.precoLiv;

                tempLivViewList.Add(tempLivView);
            }

            return View(tempLivViewList);
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