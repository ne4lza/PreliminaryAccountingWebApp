using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onMuhasebeApp.Models;
namespace onMuhasebeApp.Controllers
{
    public class CustomerProfileController : Controller
    {
        carkEntities db = new carkEntities();
        [HttpGet]
        public ActionResult Index(int id)
        {
           var query = db.TBL_Companies.ToList().Where(x => x.company_ID == id).FirstOrDefault();
            return View(query);
        }

        [HttpPost]
        public ActionResult Index(TBL_Companies company)
        {
            company.company_ID = (int)Session["company_ID"];
            company.company_Role = "C";
            company.company_ActivasionKey = "12345";
            db.Entry(company).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerProfile");
        }
    }
}