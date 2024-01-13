using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using onMuhasebeApp.Models;
namespace onMuhasebeApp.Controllers
{
    public class LoginController : Controller
    {
        carkEntities db = new carkEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_Companies c)
        {
            var query = db.TBL_Companies.ToList().Where(x=>x.company_USERN == c.company_USERN && x.company_PASSWORD == c.company_PASSWORD).FirstOrDefault();
            if(query != null) 
            {
                if(query.company_Role == "C")
                {
                    FormsAuthentication.SetAuthCookie(query.company_NAME, true);
                    Session["company_NAME"] = query.company_NAME.ToUpperInvariant();
                    Session["company_ID"] = query.company_ID;
                    Session["company_LOGO"] = query.company_LOGO;
                    return RedirectToAction("Index","Customer");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else 
            {
                ViewBag.wrongEntry = "Kullancı Adı Veya Şifre Hatalı!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult CompanyRegistration()
        {         
            return View();
        }
        [HttpPost]
        public ActionResult CompanyRegistration(TBL_Companies c)
        {
            var query = db.TBL_Companies.ToList().Where(x=>x.company_USERN == c.company_USERN).FirstOrDefault();
            if (c.company_NAME != null || c.company_sector != null || c.company_USERN != null || c.company_PASSWORD != null)
            {


                if (query == null)
                {
                    if(c.company_ActivasionKey == "12345")
                    {
                        c.company_Role = "C";
                        db.TBL_Companies.Add(c);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ViewBag.activasionError = "Aktivasyon Şfresi Hatalı. Sorun Yaşıyorsanız Lütfen Destek Ekibimize Başvurun";
                    }
                   
                }
                else
                {
                    ViewBag.sameUserError = "Bu Kullanıcı Adına Sahip Bir Kullanıcı Daha Önce Eklenmiş.";
                }
            }
            else
            {
                ViewBag.formError = "Lütfen boş alan bırakmayınız.";
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}