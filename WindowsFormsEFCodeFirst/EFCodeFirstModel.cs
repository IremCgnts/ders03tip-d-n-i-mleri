using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsEFCodeFirst
{
    public partial class EFCodeFirstModel : DbContext
    {
        public EFCodeFirstModel()
            : base("name=EFCodeFirstModel")
        {
        }

        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Urun> urunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>()
                .Property(e => e.UrunFiyati)
                .HasPrecision(18, 0);
        }
    }
}
