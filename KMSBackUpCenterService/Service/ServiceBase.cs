using KMSBackUpCenterService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Service
{
    public class ServiceBase<Rep, Entity> : IServiceBase<Entity> where Rep : IRepositoryBase<Entity>
    {
        private static Rep _repository;

        public static Rep Repository
        {
            get
            {
                if (_repository == null)
                    _repository = Activator.CreateInstance<Rep>();
                return _repository;
            }
            set { _repository = value; }
        }

        public bool Add(Entity entity)
        {
            return Repository.Add(entity);
        }

        public bool Delete(Entity entity)
        {
            return Repository.Delete(entity);
        }

        public List<Entity> List()
        {
            return Repository.List().ToList();
        }

        public bool Update(Entity entity)
        {
            return Repository.Update(entity);
        }
    }
}