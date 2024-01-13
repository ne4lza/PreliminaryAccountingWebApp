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
    public class PersonelMoneyController : Controller
    {
        carkEntities db = new carkEntities();
        [Authorize]
        public ActionResult Index()
        {
            var query = db.TBL_Money.ToList();
            return View(query);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            var model = db.TBL_Money.ToList().Where(x => x.money_ID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Update(TBL_Money m)
        {
            m.company_ID = (int)Session["company_ID"];
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "PersonelMoney");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = db.TBL_Money.Find(id);

            if (model != null)
            {
                db.TBL_Money.Remove(model);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "PersonelMoney");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(TBL_Money money)
        {
            money.company_ID = (int)Session["company_ID"];
            db.TBL_Money.Add(money);
            db.SaveChanges();
            return RedirectToAction("Index", "PersonelMoney");
        }
        [Authorize]
        public ActionResult GelirList()
        {
            int user = Convert.ToInt32(Session["company_ID"]);
            var query = db.TBL_Money.Where(x => x.company_ID == user && x.money_TYPE == "Gelir").ToList();
            if(query.Count == 0)
            {
                return RedirectToAction("Message", "PersonelMoney");  
            }
            else
            {
                return View(query);
            }
            
        }
        [Authorize]
        public ActionResult GiderList()
        {
            int user = Convert.ToInt32(Session["company_ID"]);
            var query = db.TBL_Money.Where(x => x.company_ID == user && x.money_TYPE == "Gider").ToList();
            if (query.Count == 0)
            {
                return RedirectToAction("Message", "PersonelMoney");
            }
            else
            {
                return View(query);
            }

        }

        public ActionResult Message() 
        { 
            return View();
        }
    }
}