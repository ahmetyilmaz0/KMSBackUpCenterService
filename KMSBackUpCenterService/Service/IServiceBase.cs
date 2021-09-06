using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KMSBackUpCenterService.Service
{
    [ServiceContract]
    public interface IServiceBase<Entity>
    {
        [OperationContract]
        List<Entity> List();
        [OperationContract]
        bool Add(Entity entity);
        [OperationContract]
        bool Delete(Entity entity);
        [OperationContract]
        bool Update(Entity entity);

    }
}