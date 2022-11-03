using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.ViewModels.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var secoesLiv = new List<string>
            {
                "lancamentos", "ate12reais"
            };

            ViewData["lancamentosTit"] = "Lançamentos do ano: ";
            ViewData["ate12reaisTit"] = "Baratinhos, até R$12,00: ";

            ViewData["secoes"] = secoesLiv;


            foreach (var secao in secoesLiv)
            {
                var tempLivList = new Livro().checkAllLivByFilter(secao);
                var tempLivHomeList = new List<LivrosHomeViewModel>();

                foreach (var tempLiv in tempLivList)
                {
                    var tempLivHome = new LivrosHomeViewModel
                    {
                        ISBNLiv = tempLiv.ISBNLiv,
                        titLiv = tempLiv.titLiv,
                        imgLiv = tempLiv.imgLiv,
                        precoLiv = tempLiv.precoLiv
                    };

                    tempLivHomeList.Add(tempLivHome);
                }

                ViewData[secao] = tempLivHomeList;
            }
            
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}