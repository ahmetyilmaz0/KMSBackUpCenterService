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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHashService" in both code and config file together.
    [ServiceContract]
    public interface IHashService
    {
        [OperationContract]
        string Checksum(HashingTypes hashingType, string filename);
    }
}
