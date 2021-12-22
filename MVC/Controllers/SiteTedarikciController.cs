using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SiteTedarikciController : Controller
    {
        // GET: SiteTedarikci
        Models.Model1 ctx = new Models.Model1();

        public ActionResult Getir()
        {
            var a = ctx.Tedarikciler.ToList();
            return View(a);
        }
    }
}