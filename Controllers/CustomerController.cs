using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using onMuhasebeApp.Models;
namespace onMuhasebeApp.Controllers
{
    public class CustomerController : Controller
    {
        carkEntities db = new carkEntities();
        [Authorize]
        public ActionResult Index()
        {
            decimal tlGelir=0, usdGelir=0, eurGelir = 0;
            decimal tlGider = 0,usdGider = 0 ,eurGider = 0;
            int personel = 0;
            foreach (var item in db.TBL_Money)
            {
                if(item.money_TYPE == "Gelir" && item.company_ID == (int)Session["company_ID"] && item.money_CURRENCY == "TL")
                {
                    tlGelir += (decimal)item.money_AMOUNT;
                }
                if (item.money_TYPE == "Gelir" && item.company_ID == (int)Session["company_ID"] && item.money_CURRENCY == "USD")
                {
                    usdGelir += (decimal)item.money_AMOUNT;
                }
                if (item.money_TYPE == "Gelir" && item.company_ID == (int)Session["company_ID"] && item.money_CURRENCY == "EUR")
                {
                    eurGelir += (decimal)item.money_AMOUNT;
                }
            }
            ViewBag.tlge = tlGelir;
            ViewBag.usdge = usdGelir;
            ViewBag.eurge = eurGelir;
            foreach (var item in db.TBL_Money)
            {
                if (item.money_TYPE == "Gider" && item.company_ID == (int)Session["company_ID"] && item.money_CURRENCY == "TL")
                {
                    tlGider += (decimal)item.money_AMOUNT;
                }
                if (item.money_TYPE == "Gdier" && item.company_ID == (int)Session["company_ID"] && item.money_CURRENCY == "USD")
                {
                    tlGider += (decimal)item.money_AMOUNT;
                }
                if (item.money_TYPE == "Gdier" && item.company_ID == (int)Session["company_ID"] && item.money_CURRENCY == "EUR")
                {
                    tlGider += (decimal)item.money_AMOUNT;
                }
            }
            ViewBag.tlgi = tlGider;
            ViewBag.usdgi = usdGider;
            ViewBag.eurgi = eurGider;

            foreach (var item in db.TBL_Personel)
            {
                if (item.company_ID == (int)Session["company_ID"])
                {
                    personel += 1;

                }
            }
            ViewBag.pe = personel;
            var query = db.TBL_Suppliers.ToList();
            return View(query);
           
            
        }
        [Authorize]
        public ActionResult SideNav()
        {      
            return View();
        }
        
        public ActionResult DashBoardSupplierTable()
        {
            var query = db.TBL_Suppliers.ToList();
            return View(query);
        }
        
    }
}