using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSBackUpCenterService.Repository
{
    public interface IRepositoryBase<T>
    {
        IList<T> List();
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
