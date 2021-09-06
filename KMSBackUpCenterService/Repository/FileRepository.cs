using KMSBackUpCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Repository
{
    public class FileRepository : RepositoryBase<Files>
    {
    }
    public class CustomerRepository : RepositoryBase<Customers>
    {
    }
    public class CustomerFilesRepository : RepositoryBase<CustomerFiles>
    {
    }
    public class CustomerQuotaRepository : RepositoryBase<CustomerQuota>
    {
    }
}