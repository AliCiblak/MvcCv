using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        //DbCvEntities db = new DbCvEntities();
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();//Yeteneklerim sınıfına generic üzerinden ulaşmış oluruz

        public ActionResult Index()
        {
            /*var yetenekler = db.TblYeteneklerim.ToList(); yerine repository design pattern kullanılmalı*/
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=> x.ID==id);   //Yetenek buldur
            repo.TDelete(yetenek);                  //repodaki TDelete metodunu kullan.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id) //Düzenleme yapmak için yeteneği getir
        {
            var yetenek = repo.Find(x => x.ID == id); 
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim degisen) //Düzenlenen yeteneği geri DB'ye yolla
        {
            //Kaydet butonuna basıldığında satır olarak buraya gelecek mevcut yerine degisen yazılacak.
            var mevcut = repo.Find(x => x.ID == degisen.ID);
            mevcut.Yetenek = degisen.Yetenek;
            mevcut.Oran = degisen.Oran;
            repo.TUpdate(mevcut);//degisen artık mevcutta
            return RedirectToAction("Index");
        }
        
    }
}