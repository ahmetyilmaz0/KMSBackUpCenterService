namespace KMSBackUpCenterService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Customers")]
    public partial class Customers
    {
        [Key]
        public Guid CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }
    }
}
