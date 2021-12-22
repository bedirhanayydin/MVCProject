using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {   
        // GET: Urun
        Models.Model1 ctx = new Model1();
        //ActionResult, Controller yapısına gelen isteklere göre işlem yapıp 
        //kullanıcıya View ile isteğe göre bilgileri geri döndüren metotlara 
        //verilen isimdir.
        public ActionResult Index()
        {
            //veritabanından urünleri çektim
            List<Urunler> urunler = ctx.Urunler.ToList();
            return View(urunler);
        }
        public ActionResult UrunEkle()
        {
            //viewbag controllerda olusturulan yapıyı view kısmına taşımak için kullandım.
            //viewbag içerisine kategoriler alanı açıp contextden kategorileri listeli şekilde çekilde kategorile aktar
            ViewBag.Kategoriler = ctx.Kategoriler.ToList();
            ViewBag.Tedarikciler = ctx.Tedarikciler.ToList();
            return View();
        }
        [HttpPost]//POST metodu ise URL’de görüntülenmesi istemediğimiziçin
        public ActionResult UrunEkle(Urunler u)//urun ekle de butun ınputlara name özelliği verdik urunler u yu doldurduk
        {
            ctx.Urunler.Add(u);
            ctx.SaveChanges();
            return RedirectToAction("Index");//ındex isimli actıon çalıştır
        }
        public ActionResult Sil(int id)
        {

             Urunler u = ctx.Urunler.FirstOrDefault(x => x.UrunID == id);//git veritabanından first or default seç x öyleki x.urunId si eşit eşit id olan dedim
            return View(u);//  u yuda model tipindeki view e gönder            
        }
        [HttpPost]
        public ActionResult Sil(Urunler u)
        {
            Urunler urn = ctx.Urunler.FirstOrDefault(x => x.UrunID == u.UrunID);
            ctx.Urunler.Remove(urn);
            ctx.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult UrunDetay()
        {
            //QUERY STRİNGLE id yi çekme
            int id=Convert.ToInt32( Request.QueryString["id"].ToString());
            // string adi = Request.QueryString["adi"].ToString();
            Urunler u = ctx.Urunler.FirstOrDefault(x => x.UrunID == id);
            return View(u);
        }
        public ActionResult SaveImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveImage(string HiddenId,HttpPostedFileBase UploadedImage)
        {
            if (UploadedImage.ContentLength > 0)
            {
                string ImageFileName = HiddenId + ".jpg";
                string FolderPath = Path.Combine(Server.MapPath("~/urunresim"), ImageFileName);
                UploadedImage.SaveAs(FolderPath);
            }
            ViewBag.Message = HiddenId + ".jpg isimli resim yüklendi";
            return View();
        }
        public ActionResult Guncelle_BilgiGetir(int id)
        {
            var urun = ctx.Urunler.Find(id);
            return View(urun);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Tedarikciler = ctx.Tedarikciler.ToList();
            ViewBag.Kategoriler = ctx.Kategoriler.ToList();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler u = ctx.Urunler.Find(id);
            if (u == null)
            {
                return HttpNotFound();
            }
            return View(u);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunID,UrunAdi,TedarikciID,KategoriID,Fiyat,Stok")] Urunler urun)
        {
            ViewBag.Tedarikciler = ctx.Tedarikciler.ToList();

            if (ModelState.IsValid)
            {
                ctx.Entry(urun).State = EntityState.Modified;//değişen alanları güncelle olmayanlara dokunma 
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urun);
        }
    }

    }
