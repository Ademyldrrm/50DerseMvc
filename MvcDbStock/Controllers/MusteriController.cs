using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStock.Models.Entity;

namespace MvcDbStock.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TblMüsteri select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.MÜSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniMüsteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMüsteriEkle(TblMüsteri tblMüsteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMüsteriEkle");
            }
            db.TblMüsteri.Add(tblMüsteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüsteriSil(int id)
        {
            var müsteri = db.TblMüsteri.Find(id);
            db.TblMüsteri.Remove(müsteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüsteriGetir(int id)
        {
            var mus = db.TblMüsteri.Find(id);
            return View("MüsteriGetir", mus);
        }
        public ActionResult Guncelle(TblMüsteri tblMüsteri)
        {
            var mus = db.TblMüsteri.Find(tblMüsteri.MUSTERIID);
            mus.MÜSTERIAD = tblMüsteri.MÜSTERIAD;
            mus.MUSTERISOYAD = tblMüsteri.MUSTERISOYAD;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}