using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIStudyApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "APIStudyApp";

            return View();
        }
        public ActionResult Facit()
        {
            return View();
        }
      public ActionResult AjaxTextTips()
        {
            return View();
        }
        public ActionResult AjaxJsonTips()
        {
            return View();
        }
        public ActionResult AjaxTextFacit()
        {
            return View();
        }
        public ActionResult AjaxJsonFacit()
        {
            return View();
        }
      
        public ActionResult ComingSoon()
        {
            return View();
        }
    }
}
