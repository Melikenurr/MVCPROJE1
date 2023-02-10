using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public Repository()//Constructor
        {
            _object = c.Set<T>();//Contexten gelen sınıfımı _object değerine atama işlemi.
        }
        public int Delete(T p)
        {
            _object.Remove(p);
            return c.SaveChanges();

        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
            
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }


        //lamda expressioistediğim şarta göre arama işlemi
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges();
        }
    }
}
