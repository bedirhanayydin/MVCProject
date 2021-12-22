using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SiteÜrünController : Controller
    {
        // GET: SiteÜrün
        Models.Model1 ctx = new Models.Model1();

        public ActionResult Getir()
        {
            var getir = ctx.Urunler.ToList();
            return View(getir);
        }

    }
}