using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            if (Application["AktifKullanici"]==null)
            {
                int sayac =1;
                Application["AktifKullanici"] = sayac;
            }
            else
            {
                int sayac = (int)Application["AktifKullanici"];
                sayac++;
                Application["AktifKullanici"] = sayac;
            }
            if (Application["ToplamZiyaretci"]==null)//ilk defa çalışıyorsa
            {
                int sayac = 1;
                Application["ToplamZiyaretci"] = sayac;
            }
            else
            {
                int sayac = (int)Application["ToplamZiyaretci"];
                sayac++;
                Application["ToplamZiyaretci"] = sayac;
            }
        }
        protected void Session_End()
        {
            int sayac = (int)Application["AktifKullanici"];
            sayac--;
            Application["AktifKullanici"] = sayac;
        }
    }
}
