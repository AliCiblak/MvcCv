using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedyalarim> repo = new GenericRepository<TblSosyalMedyalarim>();
        public ActionResult Index()
        {
            var sosyalMedya = repo.List();
            return View(sosyalMedya);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedyalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var medya = repo.Find(x => x.ID == id);
            repo.TDelete(medya);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var medya = repo.Find(x => x.ID == id);
            return View(medya);
        }
        [HttpPost]
        public ActionResult Duzenle(TblSosyalMedyalarim p)
        {
            
            var t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Link = p.Link;
            t.ikon = p.ikon;
            t.Durum = p.Durum;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}