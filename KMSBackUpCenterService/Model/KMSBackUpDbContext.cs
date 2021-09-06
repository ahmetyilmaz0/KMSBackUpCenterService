using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KMSBackUpCenterService.Model
{
    public partial class KMSBackUpDbContext : DbContext
    {
        public KMSBackUpDbContext()
            : base("name=KMSBackUpDb")
        {
        }

        public virtual DbSet<CustomerFiles> CustomerFiles { get; set; }
        public virtual DbSet<CustomerQuota> CustomerQuota { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
