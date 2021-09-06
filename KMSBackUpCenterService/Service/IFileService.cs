using KMSBackUpCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSBackUpCenterService.Service
{
    public interface IFileService : IServiceBase<Files>
    {
    }
    public interface ICustomerService : IServiceBase<Customers>
    {
    }
    public interface ICustomerFilesService : IServiceBase<CustomerFiles>
    {
    }
    public interface ICustomerQuotaService : IServiceBase<CustomerQuota>
    {
    }
}
