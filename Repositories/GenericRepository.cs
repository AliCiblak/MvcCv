using System;
using MvcCv.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T:class, new()
    {
        //Her defasında tablolar için crud operasyonları yazmamk zorunda kalmamak için iskeleti burada oluşturalım.
        DbCvEntities db = new DbCvEntities();
        public List<T> List()
        {
            return db.Set<T>().ToList();//T buradaki tablolar olacak.
        }
        public void TAdd(T p)//T türünden p parametresi
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}