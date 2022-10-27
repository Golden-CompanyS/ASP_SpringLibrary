using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Dashboard/Cliente
        public ActionResult Fisico()
        {
            var tempCliFList = new ClienteFisico().checkAllCliF();

            foreach (var tempCliF in tempCliFList)
            {
                tempCliF.CPFCliF = tempCliF.CPFCliF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                tempCliF.celCli = tempCliF.celCli.Insert(0, "(").Insert(3, ") ").Insert(10, "-");
                tempCliF.CEPCli = tempCliF.CEPCli.Insert(5, "-");
            }

            return View(tempCliFList);
        }

        public ActionResult Juridico()
        {
            return View();
        }
    }
}