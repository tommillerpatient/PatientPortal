using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
#if DEBUG
            ViewBag.PortaltUrl = "/patient/login/index.html";
#else
            ViewBag.PortaltUrl = "/sequenceapi/patient/login/index.html";
#endif
            return View();
        }
    }
}
