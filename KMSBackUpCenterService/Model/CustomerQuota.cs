namespace KMSBackUpCenterService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.CustomerQuota")]
    public partial class CustomerQuota
    {
        public Guid ID { get; set; }

        public long? QuotaByte { get; set; }

        public long? QuotaRemainingByte { get; set; }
    }
}
