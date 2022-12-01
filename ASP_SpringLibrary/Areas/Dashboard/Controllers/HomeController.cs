using ASP_SpringLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Areas.Dashboard.Controllers
{
    [CustomAuthorize("Funcionário")]
    public class HomeController : Controller
    {
        // GET: Dashboard/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}