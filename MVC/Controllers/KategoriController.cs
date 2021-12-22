using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{   [Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori
        Models.Model1 ctx = new Models.Model1();
        public ActionResult Index()
        {
            List<Kategoriler> ktg = ctx.Kategoriler.ToList();
            return View(ktg);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kategoriler k)
        {
            ctx.Kategoriler.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public void Sil(int id)
        {//veritabanındakı kategorilerden kategori id İD ye eşit olanı k ya aktar
            Kategoriler k = ctx.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            ctx.Kategoriler.Remove(k);
            ctx.SaveChanges();
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = ctx.Kategoriler.Find(id);
            return View(kategori);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler ktg = ctx.Kategoriler.Find(id);
            if (ktg == null)
            {
                return HttpNotFound();
            }
            return View(ktg);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriID,KategoriAdi,Tanimi")] Kategoriler kategori)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(kategori).State = EntityState.Modified;//değişen alanları güncelle olmayanlara dokunma 
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }


    }
}