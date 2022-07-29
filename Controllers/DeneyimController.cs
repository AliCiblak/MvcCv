using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.TAdd(p);                           //Ekle
            return RedirectToAction("Index");       //Index sayfasına yönlendir.
        }
        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            /*
             * Düzenle kısmına basıldığında seçilen id'deki deneyimi p ile alıyoruz.
             * Güncellemeyi yapıp tekrar gönderdiğimizde p parametresinden gelen deneyimi t'nin içine atarız.
             */
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);                                   //t'den gelen değeri güncelle
            return RedirectToAction("Index");                 //Index sayfasına yönlendir.
        }
    }
}