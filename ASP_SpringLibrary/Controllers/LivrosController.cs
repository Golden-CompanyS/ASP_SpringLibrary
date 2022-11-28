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
        public ActionResult Index(string busca)
        {
            var tempLivList = new List<Livro>();
            var tempLivViewList = new List<LivrosHomeViewModel>();

            if (busca == null)
            {
                tempLivList = new Livro().checkAllLiv();
            }
            else
            {
                tempLivList = new Livro().checkAllLivByFilter("titulo", busca);
            }

            
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
        public ActionResult Detalhes(string id)
        {
            if (id == null || id == "")
            {
                return RedirectToAction("Index");
            }

            var tempLiv = new Livro().checkLivByISBN(id);

            return View(tempLiv);
        }
    }
}