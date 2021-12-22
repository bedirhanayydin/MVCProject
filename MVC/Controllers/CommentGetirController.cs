using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;


namespace MVC.Controllers
{
    public class CommentGetirController : Controller
    {
        // GET: CommentGetir
        Models.Model1 ctx = new Models.Model1();

        public ActionResult Index()
        {
            List<Contact> cmt = ctx.Contact.ToList();
            return View(cmt);
        }
        [HttpPost]
        public void Sil(int id)
        {//veritabanındakı kategorilerden kategori id İD ye eşit olanı k ya aktar
            Contact k = ctx.Contact.FirstOrDefault(x => x.ContactID == id);
            ctx.Contact.Remove(k);
            ctx.SaveChanges();
        }
    }
}