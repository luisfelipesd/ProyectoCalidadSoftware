using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index(int? nuevo)
        {
            if (nuevo != null)
                ViewBag.nuevo = nuevo;
            else
                ViewBag.nuevo = 0;
                                 
            return View();
        }
    }
}