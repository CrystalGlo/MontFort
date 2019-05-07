using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontFort.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "La page de description de l'application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "La page de contact";

            return View();
        }

        public ActionResult Resident()
        {
            ViewBag.Message = "La page des résidents";

            return View();
        }
    }
}