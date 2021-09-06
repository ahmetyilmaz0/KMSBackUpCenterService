using KMSBackUpCenterService.Model;
using KMSBackUpCenterService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Service
{
    public class FileService : ServiceBase<FileRepository, Files>, IFileService
    {
    }
    public class CustomerService : ServiceBase<CustomerRepository, Customers>, ICustomerService
    {
    }
    public class CustomerFilesService : ServiceBase<CustomerFilesRepository, CustomerFiles>, ICustomerFilesService
    {
    }
    public class CustomerQuotaService : ServiceBase<CustomerQuotaRepository, CustomerQuota>,ICustomerQuotaService
    {
    }
}