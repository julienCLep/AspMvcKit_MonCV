using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skillz.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Bienvenue. <a href=\"/home/about\">Cliquez ici pour accéder à l'application</a>";
        }

        public ActionResult About()
        {
            return View();
        }
    }
}