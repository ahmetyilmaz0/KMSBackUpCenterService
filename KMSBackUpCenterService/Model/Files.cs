namespace KMSBackUpCenterService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Files")]
    public partial class Files
    {
        [Key]
        public Guid FileID { get; set; }

        public string FileName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FileCreationDate { get; set; }

        public string FileDirectory { get; set; }

        public string FileExtension { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FileLastAccessDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FileLastWriteDate { get; set; }

        public string FileMD5 { get; set; }

        public string FileSHA256 { get; set; }

        public DateTime? FileAddingTime { get; set; }
    }
}
