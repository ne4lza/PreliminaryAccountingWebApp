using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using onMuhasebeApp.Models;
namespace onMuhasebeApp.Controllers
{
    public class PersonelController : Controller
    {
        carkEntities db = new carkEntities();
        [Authorize]
        public ActionResult Index()
        {
            var query = db.TBL_Personel.ToList();
            return View(query);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            var model = db.TBL_Personel.ToList().Where(x => x.personel_ID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Update(TBL_Personel p)
        {
            p.company_ID = (int)Session["company_ID"];
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Add(TBL_Personel personel)
        {
            var query = db.TBL_Personel.ToList().Where(x => x.personel_TC == personel.personel_TC).FirstOrDefault();
            if (query == null)
            {
                personel.company_ID = (int)Session["company_ID"];
                db.TBL_Personel.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index", "Personel");
            }
            else
            {
                ViewBag.sameUserError = "Bu TCKN'ye Ait Bir Kayıt Zaten Ekli";
            }
            return View();
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = db.TBL_Personel.Find(id);

            if (model != null)
            {
                db.TBL_Personel.Remove(model);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Personel");
        }




    }
}