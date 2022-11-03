using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    public class AutorController : Controller
    {
        // GET: Dashboard/Autor
        public ActionResult Index()
        {
            var tempAutList = new Autor().checkAllAut();

            return View(tempAutList);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Autor autor)
        {
            if (ModelState.IsValid)
            {
                new Autor().cadAut(autor);

                return RedirectToAction("Index");
            }

            return View(autor);
        }
        public JsonResult AutExists(int idAut, string nomAut)
        {
            bool AutExists = new Autor().autExists(idAut, nomAut); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!AutExists, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var tempAut = new Autor().checkAutById(id);

            return View(tempAut);
        }

        [HttpPost]
        public ActionResult Alterar(Autor autor)
        {
            if (ModelState.IsValid)
            {
                new Autor().altAut(autor);

                return RedirectToAction("Index");
            }

            return View(autor);
        }
    }
}