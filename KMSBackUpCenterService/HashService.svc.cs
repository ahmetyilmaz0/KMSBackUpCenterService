using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KMSBackUpCenterService
{
    using static KMSBackUpCenterService.Extensions.HashExtensions;
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HashService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HashService.svc or HashService.svc.cs at the Solution Explorer and start debugging.
    public class HashService : IHashService
    {
        public string Checksum(HashingTypes hashingType, string filename)
        {
            return GetChecksum(hashingType, filename);
        }

    }
}
