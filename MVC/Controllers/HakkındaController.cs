using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HakkındaController : Controller
    {
        // GET: Hakkında
        Models.Model1 ctx = new Models.Model1();

        public ActionResult Index()
        {
            var a = ctx.Anasayfa.ToList();
            return View(a);
        }
    }
}