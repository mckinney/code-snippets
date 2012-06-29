using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McKinney.Analytics;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            // something special happened, let's track it
            GoogleAnalytics.PushEvent("My Category", "My Action", "An optional label");
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
