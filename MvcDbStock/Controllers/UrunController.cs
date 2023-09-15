using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStock.Models.Entity;

namespace MvcDbStock.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var değerler = db.TblUrunler.ToList();
            return View(değerler);
        }
        [HttpGet]
        public ActionResult YeniÜrünEkle()
        {
            List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORID.ToString()
                                             }).ToList();
            ViewBag.item = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniÜrünEkle(TblUrunler tblUrunler)
        {
            var ktg = db.TblKategori.Where(x => x.KATEGORID == tblUrunler.TblKategori.KATEGORID).FirstOrDefault();
            tblUrunler.TblKategori = ktg;
            db.TblUrunler.Add(tblUrunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var degerler = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(degerler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGüncelle(int id)
        {
            var urun = db.TblUrunler.Find(id);

            List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORID.ToString()
                                             }).ToList();
            ViewBag.item = degerler;
            return View("UrunGüncelle", urun);

        }
        public ActionResult UrunGetir(TblUrunler tblUrunler)
        {
            var result = db.TblUrunler.Find(tblUrunler.URUNID);
            result.URUNAD = tblUrunler.URUNAD;
            result.MARKA = tblUrunler.MARKA;
            result.STOK = tblUrunler.STOK;
            result.FIYAT = tblUrunler.FIYAT;
            result.URUNKATEGORI = tblUrunler.URUNKATEGORI;
            var ktg = db.TblKategori.Where(x => x.KATEGORID == tblUrunler.TblKategori.KATEGORID).FirstOrDefault();
            result.URUNKATEGORI = ktg.KATEGORID;
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View("UrunGüncelle", urun);

        }

    }
}