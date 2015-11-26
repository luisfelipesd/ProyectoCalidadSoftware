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
            if (nuevo == 1)
                ViewBag.nuevo = -1;
            else
                ViewBag.nuevo = 0;
                                 
            return View();
        }
    }
}