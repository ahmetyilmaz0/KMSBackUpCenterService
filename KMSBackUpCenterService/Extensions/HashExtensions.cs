using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Extensions
{
    public class HashExtensions
    {
        public static string GetChecksum(HashingTypes hashingType, string filename)
        {
            using (var hasher = System.Security.Cryptography.HashAlgorithm.Create(hashingType.ToString()))
            {
                using (var stream = System.IO.File.OpenRead(filename))
                {
                    var hash = hasher.ComputeHash(stream);
                    stream.Close();
                    return BitConverter.ToString(hash).Replace("-", "");
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