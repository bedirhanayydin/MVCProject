using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{  
    using App_Classes;
    using System.Web.Security;
    [Authorize]
    public class UyeController : Controller
    {
        // GET: Uye
        [AllowAnonymous]  //giris yap [Authorize] bundan etkıllenmemsı lazım cunku gırıs yap
        public ActionResult GirisYap()
        {
            return View();  
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GirisYap(Kullanici k)
        {
           bool sonuc= Membership.ValidateUser(k.KullaniciAdi, k.Sifre);
            if (sonuc==true)      //girilen kullanıc adı ve sifre varsa tıklamışsa
            {   
                FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Parola Hatalı!!!";
                return View();
            }
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }
        [AllowAnonymous]
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SifremiUnuttum(Kullanici k)
        {
            MembershipUser mu = Membership.GetUser(k.KullaniciAdi);
            if (mu.PasswordQuestion==k.GizliSoru)     //membershıpın ıcındekı gızlı soruyla kullanıcının girdiği gizli soru eşitmi
            {    //kullanıcının getpasswordle gizlicevabı gilen kullanıcının şifresini ggetir
                string sifre = mu.GetPassword(k.GizliCevap);
                mu.ChangePassword(sifre, k.Sifre);
                return RedirectToAction("GirisYap");
            }
            else
            {
                ViewBag.Mesaj = "Girilen Bilgiler Yanlıştır";
                return View();
            }
        }
    }
}