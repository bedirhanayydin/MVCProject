using MVC.App_Classes;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        Models.Model1 ctx = new Models.Model1();
        public ActionResult Index()
        {
            MembershipUserCollection kullanicilar= Membership.GetAllUsers();
            return View(kullanicilar);
        }
        [AllowAnonymous]
        public ActionResult Ekle()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Ekle(Kullanici k)
        {
            MembershipCreateStatus durum;
            // createuser 3.kullanım şeklini kullandık
            Membership.CreateUser(k.KullaniciAdi, k.Sifre, k.Email, k.GizliSoru, k.GizliCevap,true,out durum);
            string mesaj = " ";
            switch (durum)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += " Geçersiz Kullanıcı Adı Girildi.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj += " Geçersiz Parola Girildi.";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += " Geçersiz Soru.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += " Geçersiz Cevap Girildi.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += " Geçersiz Mail Adresi Girildi.";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += " Kullanılmış Kullanıcı Adı Girildi.";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += " Kullanılmış Mail Adresi Girildi.";
                    break;
                case MembershipCreateStatus.UserRejected:
                    mesaj += " Kullanıcı Engel Hatası.";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    mesaj += " Geçersiz Kullanıcı Key Hatası.";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    mesaj += " Kullanılmış Kullanıcı Key Hatası.";
                    break;
                case MembershipCreateStatus.ProviderError:
                    mesaj += " Üye Yönetimi Sağlayıcısı Hatası.";
                    break;
                default:
                    break;
            }
            ViewBag.Mesaj = mesaj;
            if (durum == MembershipCreateStatus.Success)
                return RedirectToAction("Index");
            else
                return View();
            
        }
         [Authorize(Roles="Admin")]     //sadece admin ve müdür rolündeki kullanıcılar açabilir
         public ActionResult RolAta()
        {

            ViewBag.Roller = Roles.GetAllRoles().ToList();
            ViewBag.Kullanicilar = Membership.GetAllUsers();
            return View();
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public ActionResult RolAta(string KullaniciAdi,string RolAdi)
        {
            Roles.AddUserToRole(KullaniciAdi,RolAdi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string UyeRolleri(string kullaniciAdi)
        {
           List<string> roller= Roles.GetRolesForUser(kullaniciAdi).ToList();
            //rolleri listeleme en sonda kalan tire- işaretini silme işlemi
            string rol = "";
            foreach(string r in roller) {
                rol += r + "-";
            }
            rol = rol.Remove(rol.Length - 1, 1);
            return rol;
        }
        public ActionResult Sil(string username)
        {

            aspnet_Users u = ctx.aspnet_Users.FirstOrDefault(x => x.UserName == username);//git veritabanından first or default seç x öyleki x.urunId si eşit eşit id olan dedim
            return View(u);//  u yuda model tipindeki view e gönder            
        }
        [HttpPost]
        public ActionResult Sil(aspnet_Users u)
        {
            aspnet_Users username = ctx.aspnet_Users.FirstOrDefault(x =>x.UserName  == u.UserName);
            ctx.aspnet_Users.Remove(username);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}