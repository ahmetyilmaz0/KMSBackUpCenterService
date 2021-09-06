using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSBackUpCenterService.Forms
{
    using FileServiceReference;
    using HashServiceReference;
    using System.ComponentModel;
    using System.Configuration;

    public class UploadFile
    {
        public async Task<string> Upload(string filename,string customer, string customername,string directory)
        {
            //Custoemr Autohentication
            using (FileStream SourceStream = File.OpenRead(filename))
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServerHost"];
                byte[] buffer = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(buffer, 0, (int)SourceStream.Length);
                SourceStream.Close();
                HashServiceClient hashServiceClient = new HashServiceClient();
                //var md5 = hashServiceClient.GetChecksum(HashServiceHashingTypes.MD5, filename);
                //var sha256 = hashServiceClient.GetChecksum(HashServiceHashingTypes.SHA256, filename);

                var md5 = ChecksumUtil.GetChecksum(HashingTypes.MD5, filename);
                var sha256 = ChecksumUtil.GetChecksum(HashingTypes.SHA256, filename);

                System.IO.FileInfo FileInfo = new System.IO.FileInfo(filename);

                FileInfo fileInfo = new FileInfo()
                {
                    CustomerID = Guid.Parse(customer),
                    CustomerName = customername,
                    Name = FileInfo.Name,
                    Extension = FileInfo.Extension,
                    CreationTime = FileInfo.CreationTime,
                    Directory = smtpHost,//"C:\\Users\\ahmet\\Backups\\",
                    LastAccessTime = FileInfo.LastAccessTime,
                    LastWriteTime = FileInfo.LastWriteTime,
                    FileMD5 = md5,
                    FileSHA256 = sha256,
                    Lenght = FileInfo.Length  
                };
                FileCenterServiceClient client = new FileCenterServiceClient();
                return await client.POSTAsync(buffer, fileInfo);
            }
        }
        public static class ChecksumUtil
        {
            public static string GetChecksum(HashingTypes hashingType, string filename)
            {
                using (var hasher = System.Security.Cryptography.HashAlgorithm.Create(hashingType.ToString()))
                {
                    using (var stream = System.IO.File.OpenRead(filename))
                    {
                        var hash = hasher.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "");
                    }
                }
            }
        }
        public enum HashingTypes
        {
            MD5,
            SHA1,
            SHA256,
            SHA384,
            SHA512
        }
    }
}
