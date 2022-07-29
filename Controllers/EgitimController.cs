using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    //[Authorize] Burada bulunan bütün metotlar için geçerli olur.
    /*Authorize Nedir: Burada bulunan arayüzlere erişmek için oturum açmamız gerektiğini söylemiş oluruz*/
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
                /*Eğer validasyonlardaki değeri ezecek bir hamle yapıldıysa
                 * EgitimEkleyi geri döndür ve işlemi gerçekleştirme
                 (Başlık kısmının boş bırakılmaya çalışılması gibi)*/
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        /* Bu kısımda boş ekleme yapmasın diye Model kısmında çalışılan
         * tabloya gidilip alanların Required yapılması gerekir.
         * Yani alanların boş geçilemez olması sağlanır. */
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x=>x.ID==t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik = t.AltBaslik;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.GNO = t.GNO;
            egitim.Tarih = t.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}