using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Ubiety.Dns.Core.Common;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    public class EditoraController : Controller
    {
        // GET: Dashboard/Editora
        public ActionResult Index()
        {
            var tempEditList = new Editora().checkAllEdit();

            foreach (var tempEdit in tempEditList)
            {
                tempEdit.celEdit = tempEdit.celEdit.Insert(0, "(").Insert(3, ") ").Insert(10, "-");
            }

            return View(tempEditList);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Editora editora)
        {
            if (ModelState.IsValid)
            {
                editora.celEdit = string.Concat(editora.celEdit.Where(Char.IsDigit));
                new Editora().cadEdit(editora);

                return RedirectToAction("Index");
            }

            return View(editora);
        }

        public JsonResult EditExists(int idEdit, string nomEdit)
        {
            bool editExists = new Editora().editExists(idEdit, nomEdit); // Checar existência do nome (deve ser único), se não já atrelado ao ID

            return Json(!editExists, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var tempEdit = new Editora().checkEditById(id);

            return View(tempEdit);
        }

        [HttpPost]
        public ActionResult Alterar(Editora editora)
        {
            if (ModelState.IsValid)
            {
                editora.celEdit = string.Concat(editora.celEdit.Where(Char.IsDigit));
                new Editora().altEdit(editora);

                return RedirectToAction("Index");
            }

            return View(editora);
        }
    }
}