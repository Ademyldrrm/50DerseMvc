using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStock.Models.Entity;

namespace MvcDbStock.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatislar tblSatislar)
        {
            db.TblSatislar.Add(tblSatislar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
