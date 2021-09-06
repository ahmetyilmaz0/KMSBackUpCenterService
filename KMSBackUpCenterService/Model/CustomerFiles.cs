namespace KMSBackUpCenterService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.CustomerFiles")]
    public partial class CustomerFiles
    {
        [Key]
        public Guid CF_ID { get; set; }

        public Guid CF_CustomerID { get; set; }

        public Guid CF_FileID { get; set; }
    }
}
