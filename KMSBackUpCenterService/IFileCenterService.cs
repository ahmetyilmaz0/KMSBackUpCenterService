using KMSBackUpCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KMSBackUpCenterService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileCenterService" in both code and config file together.
    [ServiceContract]
    public interface IFileCenterService
    {
        [OperationContract(IsOneWay = false, AsyncPattern = true)]
        Task<string> POST(FileInfo fileInfo);

        [OperationContract(IsOneWay = false, AsyncPattern = true)]
        Task<FileInfo> GET(FileInfo fileInfo);

        [OperationContract(IsOneWay = false, AsyncPattern = true)]
        Task<List<Files>> GetFiles(string Customer);

        [OperationContract(IsOneWay = false, AsyncPattern = true)]
        Task<CustomerQuota> GetQuotas(string Customer);
    }
}
