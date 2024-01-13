using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onMuhasebeApp.Models;
namespace onMuhasebeApp.Controllers
{
    public class CustomerStockController : Controller
    {
        carkEntities db = new carkEntities();
        public ActionResult Index()
        {
            var query = db.TBL_Stock.ToList();
            return View(query);
        }
    }
}