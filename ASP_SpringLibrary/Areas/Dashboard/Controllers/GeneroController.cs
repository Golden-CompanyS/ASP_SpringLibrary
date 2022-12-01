using ASP_SpringLibrary.Models;
using ASP_SpringLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    [CustomAuthorize("Funcionário")]
    public class GeneroController : Controller
    {
        // GET: Dashboard/Genero
        public ActionResult Index()
        {
            var tempGenList = new Genero().checkAllGen();
            
            return View(tempGenList);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Genero genero)
        {
            if (ModelState.IsValid)
            {
                new Genero().cadGen(genero);

                return RedirectToAction("Index");
            }

            return View(genero);
        }

        public JsonResult GenExists(int idGen, string nomGen)
        {
            bool genExists = new Genero().genExists(idGen, nomGen); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!genExists, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var tempGen = new Genero().checkGenById(id);

            return View(tempGen);
        }

        [HttpPost]
        public ActionResult Alterar(Genero genero)
        {
            if (ModelState.IsValid)
            {
                new Genero().altGen(genero);

                return RedirectToAction("Index");
            }

            return View(genero);
        }
    }
}