using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class TedarikciController : Controller
    {
        // GET: Tedarikci
        Models.Model1 ctx = new Models.Model1();
        public ActionResult Index()
        {
            List<Tedarikciler> veriler = ctx.Tedarikciler.ToList();
            return View(veriler);
        }
        [HttpPost]                          
        public string Sil(int id)
        {
            Tedarikciler ted = ctx.Tedarikciler.FirstOrDefault(x => x.TedarikciID == id);
            ctx.Tedarikciler.Remove(ted);
            try //diğer tablolarla ilişkili olursa hata vermesin
            {
                ctx.SaveChanges();
                return "Başarılı";
            }
            catch (Exception)
            {
                return "HATA";           
            }
            
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tedarikciler ted)
        {
            ctx.Tedarikciler.Add(ted);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle_BilgiGetir(int id)
        {
            var tedarikci = ctx.Tedarikciler.Find(id);
            return View(tedarikci);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikciler ted = ctx.Tedarikciler.Find(id);
            if (ted == null)
            {
                return HttpNotFound();
            }
            return View(ted);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TedarikciID,SirketAdi,MusteriAdi,Adres,Sehir,Bolge,PostaKodu,Ulke,Telefon,Faks")] Tedarikciler teda)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(teda).State = EntityState.Modified;//değişen alanları güncelle olmayanlara dokunma 
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teda);
        }

        public ActionResult SImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SImage(string HiddenId, HttpPostedFileBase UploadedImage)
        {
            if (UploadedImage.ContentLength > 0)
            {
                string ImageFileName = HiddenId + ".jpg";
                string FolderPath = Path.Combine(Server.MapPath("~/tedarikciresim"), ImageFileName);
                UploadedImage.SaveAs(FolderPath);
            }
            ViewBag.Message = HiddenId + ".jpg isimli resim yüklendi";
            return View();
        }
    }
}