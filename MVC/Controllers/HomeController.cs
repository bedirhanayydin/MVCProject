using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {   [Authorize]   //sisteme giriş yapılmadan hiçbir sayfaya gitmesin
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AktifKullanici = HttpContext.Application["AktifKullanici"];
            ViewBag.ToplamZiyaretci = HttpContext.Application["ToplamZiyaretci"];
            return View();
        }
    }
}