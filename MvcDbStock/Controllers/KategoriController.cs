using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDbStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcDbStock.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index(int sayfa=1)
        {
        //    var value = db.TblKategori.ToList();
            var degerler = db.TblKategori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategoriEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniKategoriEkle(TblKategori tblKategori)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategoriEkle");
            }
            db.TblKategori.Add(tblKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategori.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TblKategori tblKategori)
        {
            var ktgr = db.TblKategori.Find(tblKategori.KATEGORID);
            ktgr.KATEGORİAD = tblKategori.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}