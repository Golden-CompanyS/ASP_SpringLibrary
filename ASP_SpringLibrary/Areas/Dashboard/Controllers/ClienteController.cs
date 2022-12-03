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
            var tempCliJList = new ClienteJuridico().checkAllCliJ();

            foreach (var tempCliJ in tempCliJList)
            {
                tempCliJ.CNPJCliJ = tempCliJ.CNPJCliJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                tempCliJ.celCli = tempCliJ.celCli.Insert(0, "(").Insert(3, ") ").Insert(10, "-");
                tempCliJ.CEPCli = tempCliJ.CEPCli.Insert(5, "-");
            }

            return View(tempCliJList);
        }
    }
}