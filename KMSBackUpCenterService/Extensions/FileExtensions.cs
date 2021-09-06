using KMSBackUpCenterService.Model;
using KMSBackUpCenterService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMSBackUpCenterService.Extensions
{
    public static class FileExtensions
    {
        public static string CheckQuota(Guid CustomerGuid, long Lenght)
        {
            try
            {
                CustomerQuotaService quotaService = new CustomerQuotaService();
                var data = quotaService.List().FirstOrDefault(x => x.ID == CustomerGuid);
                if (quotaService.List().FirstOrDefault(x => x.ID == CustomerGuid).QuotaRemainingByte >= Lenght) return "OK";
                else return "NaN";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string AddFile(FileInfo fileInfo)
        {
            try
            {
                #region File
                Files files = new Files()
                {
                    FileID = Guid.NewGuid(),
                    FileName = fileInfo.Name,
                    FileDirectory = fileInfo.Directory,
                    FileExtension = fileInfo.Extension,
                    FileCreationDate = fileInfo.CreationTime,
                    FileLastAccessDate = fileInfo.LastAccessTime,
                    FileLastWriteDate = fileInfo.LastWriteTime,
                    FileMD5 = fileInfo.FileMD5,
                    FileSHA256 = fileInfo.FileSHA256,
                    FileAddingTime = DateTime.Now
                };
                #endregion
                #region CustomerFiles
                CustomerFiles customerFiles = new CustomerFiles()
                {
                    CF_ID = Guid.NewGuid(),
                    CF_FileID = files.FileID,
                    CF_CustomerID = fileInfo.CustomerID
                };
                #endregion
                #region CustomerQuota
                CustomerQuotaService customerQuotaService = new CustomerQuotaService();
                var customerQuota = customerQuotaService.List().FirstOrDefault(x => x.ID == fileInfo.CustomerID);
                var oldQuota = customerQuota;
                customerQuota.QuotaRemainingByte = customerQuota.QuotaRemainingByte - fileInfo.Lenght;
                #endregion

                if (customerQuotaService.Update(customerQuota))
                {
                    FileService fileService = new FileService();
                    if (fileService.Add(files))
                    {
                        CustomerFilesService customerFilesService = new CustomerFilesService();
                        if (customerFilesService.Add(customerFiles)) return "OK";
                        else
                        {
                            fileService.Delete(files);
                            return "NaN";
                        }
                    }
                    else
                    {
                        customerQuotaService.Update(oldQuota);
                        return "NaN";
                    }
                }
                else return "NaN";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static List<Files> ListFiles(string Customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                var customer = customerService.List().FirstOrDefault(x => x.CustomerID == Guid.Parse(Customer));
                if (customer != null)
                {
                    CustomerFilesService customerFilesService = new CustomerFilesService();
                    var customerfiles = customerFilesService.List().Where(x => x.CF_CustomerID == customer.CustomerID);
                    if (customerfiles != null)
                    {
                        FileService fileService = new FileService();
                        List<Files> files = new List<Files>();
                        foreach (var item in customerfiles)
                        {
                            files.Add(fileService.List().FirstOrDefault(x => x.FileID == item.CF_FileID));
                        }
                        return files;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public static CustomerQuota ListQuota(string Customer)
        {
            try
            {
                CustomerQuotaService quotaService = new CustomerQuotaService();
                return quotaService.List().FirstOrDefault(x => x.ID == Guid.Parse(Customer));
            }
            catch (Exception)
            {
                return null;
            }
        }       
    }
}