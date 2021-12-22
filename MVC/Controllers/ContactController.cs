using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Models.Model1 ctx = new Models.Model1();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact p1)
        {
            ctx.Contact.Add(p1);
            ctx.SaveChanges();
            return RedirectToAction("Contact","Contact");
        }
    }
}