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
    public class VendaController : Controller
    {
        // GET: Dashboard/Venda
        public ActionResult Index()
        {
            var tempNfList = new NotaFiscal().checkAllNf();

            return View(tempNfList);
        }

        public ActionResult altStatus(int idDel, int status)
        {
            new Delivery().altStatusDeliv(idDel, status);

            return RedirectToAction("Index");
        }
    }
}