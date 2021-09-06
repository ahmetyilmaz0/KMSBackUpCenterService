using KMSBackUpCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private static KMSBackUpDbContext context;

        public KMSBackUpDbContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new KMSBackUpDbContext();
                }

                return context;
            }
            set { context = value; }
        }

        public IList<T> List()
        {
            return Context.Set<T>().ToList();
        }

        public bool Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
                Context = new KMSBackUpDbContext();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(T entity)
        {

            try
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
                Context = new KMSBackUpDbContext();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                //Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}