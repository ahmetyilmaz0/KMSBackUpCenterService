using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMSBackUpCenterService.Extensions
{
    public class ReturnTypeExtensions
    {
        public enum ReturnType
        {
            POSTSucces,
            GETError,
            SHA256,
            SHA384,
            SHA512
        }
    }
}