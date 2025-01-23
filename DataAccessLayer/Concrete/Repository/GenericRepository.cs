using DataAccessLayer.Absract;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {
            using var context = new TarimWebSiteContext();
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
           using var context = new TarimWebSiteContext();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var context = new TarimWebSiteContext();
            return context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            using var context = new TarimWebSiteContext();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new TarimWebSiteContext();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
