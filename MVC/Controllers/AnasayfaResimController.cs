using MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AnasayfaResimController : Controller
    {
        Models.Model1 ctx = new Models.Model1();
        public ActionResult Index()
        {
            List<Anasayfa> veriler = ctx.Anasayfa.ToList();
            return View(veriler);
        }
        public ActionResult ResımEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResımEkle(string HiddenId, HttpPostedFileBase UploadedImage)
        {
            if (UploadedImage.ContentLength > 0)
            {
                string ImageFileName = HiddenId + ".jpg";
                string FolderPath = Path.Combine(Server.MapPath("~/anasayfaresim"), ImageFileName);
                UploadedImage.SaveAs(FolderPath);
            }
            ViewBag.Message = HiddenId + ".jpg isimli resim yüklendi";
            return View();
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle( Anasayfa a)
        {
            ctx.Anasayfa.Add(a);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}