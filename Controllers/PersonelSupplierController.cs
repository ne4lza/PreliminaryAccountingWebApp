using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using onMuhasebeApp.Models;
namespace onMuhasebeApp.Controllers
{
    public class PersonelSupplierController : Controller
    {
        carkEntities db = new carkEntities();
        [Authorize]
        public ActionResult Index()
        {
            var query = db.TBL_Suppliers.ToList();
            return View(query);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            var model = db.TBL_Suppliers.ToList().Where(x => x.supplier_ID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Update(TBL_Suppliers s)
        {
            s.company_ID = (int)Session["company_ID"];
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "PersonelSupplier");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Add(TBL_Suppliers sup)
        {
            var query = db.TBL_Suppliers.ToList().Where(x => x.supplier_ID == sup.supplier_ID).FirstOrDefault();
            if (query == null)
            {
                sup.company_ID = (int)Session["company_ID"];
                db.TBL_Suppliers.Add(sup);
                db.SaveChanges();
                return RedirectToAction("Index", "PersonelSupplier");
            }
            else
            {
                
            }
            return View();
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = db.TBL_Suppliers.Find(id);

            if (model != null)
            {
                db.TBL_Suppliers.Remove(model);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "PersonelSupplier");
            
        }
    }
}