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
    using static KMSBackUpCenterService.Extensions.FileExtensions;
    using static KMSBackUpCenterService.Extensions.HashExtensions;
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileCenterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FileCenterService.svc or FileCenterService.svc.cs at the Solution Explorer and start debugging.
    public class FileCenterService : IFileCenterService
    {
        public async Task<string> POST(FileInfo fileInfo)
        {
            try
            {
                if (CheckQuota(fileInfo.CustomerID, fileInfo.Lenght) == "OK")
                {
                    fileInfo.Directory = $"{fileInfo.Directory}{fileInfo.CustomerID}\\";
                    if (!System.IO.Directory.Exists(fileInfo.Directory))
                        System.IO.Directory.CreateDirectory(fileInfo.Directory);
                    //
                    foreach (var item in System.IO.Directory.GetFiles(fileInfo.Directory))
                    {
                        if ($"{fileInfo.Directory}{fileInfo.Name}" == item)
                        {
                            fileInfo.Name = fileInfo.Name.Replace(fileInfo.Extension, $"_1{fileInfo.Extension}");
                        }
                    }
                    //
                    using (System.IO.FileStream SourceStream = System.IO.File.Create(fileInfo.Directory + fileInfo.Name))
                    {
                        SourceStream.Seek(0, System.IO.SeekOrigin.End);
                        await SourceStream.WriteAsync(fileInfo.File, 0, fileInfo.File.Length);
                        SourceStream.Close();

                        if (GetChecksum(HashingTypes.MD5, fileInfo.Directory + fileInfo.Name) == fileInfo.FileMD5)
                        {
                            if (GetChecksum(HashingTypes.SHA256, fileInfo.Directory + fileInfo.Name) == fileInfo.FileSHA256)
                            {
                                if (AddFile(fileInfo) == "OK")
                                {
                                    return await Task.FromResult("OK");
                                }
                            }
                        }
                    }
                    System.IO.File.Delete(fileInfo.Directory + fileInfo.Name);
                    return await Task.FromResult("NaN");
                }
                else return await Task.FromResult("NaN");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.ToString());
            }
        }

        public async Task<FileInfo> GET(FileInfo FileInfo)
        {
            if (System.IO.Directory.Exists(FileInfo.Directory))
            {
                foreach (var item in System.IO.Directory.GetFiles(FileInfo.Directory))
                {
                    if ($"{FileInfo.Directory}{FileInfo.Name}" == item)
                    {
                        using (System.IO.FileStream SourceStream = System.IO.File.OpenRead(item))
                        {
                            FileInfo.File = new byte[SourceStream.Length];
                            await SourceStream.ReadAsync(FileInfo.File, 0, (int)SourceStream.Length);
                            SourceStream.Close();

                            var md5 = GetChecksum(HashingTypes.MD5, item);
                            var sha256 = GetChecksum(HashingTypes.SHA256, item);

                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(item);
                            //
                            //FileInfo File = new FileInfo()
                            //{

                            //};
                            FileInfo.Name = fileInfo.Name;
                            FileInfo.Extension = fileInfo.Extension;
                            FileInfo.CreationTime = fileInfo.CreationTime;
                            FileInfo.LastAccessTime = fileInfo.LastAccessTime;
                            FileInfo.LastWriteTime = fileInfo.LastWriteTime;
                            FileInfo.FileMD5 = md5;
                            FileInfo.FileSHA256 = sha256;
                            FileInfo.Lenght = fileInfo.Length;
                            return await Task.FromResult(FileInfo);
                        }
                    }
                }
                return null;
            }
            else return null;
        }
        public async Task<List<Files>> GetFiles(string Customer)
        {
            return await Task.FromResult(ListFiles(Customer).ToList());
        }
        public async Task<CustomerQuota> GetQuotas(string Customer)
        {
            return await Task.FromResult(ListQuota(Customer));
        }
    }
}
