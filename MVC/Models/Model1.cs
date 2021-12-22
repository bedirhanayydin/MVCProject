namespace MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web.Security;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }

        public virtual DbSet<Bolge> Bolge { get; set; }
        public virtual DbSet<Bolgeler> Bolgeler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<MusteriDemographics> MusteriDemographics { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Nakliyeciler> Nakliyeciler { get; set; }
        public virtual DbSet<Personeller> Personeller { get; set; }
        public virtual DbSet<SatisDetay> SatisDetay { get; set; }
        public virtual DbSet<Satislar> Satislar { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tedarikciler> Tedarikciler { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Anasayfa> Anasayfa { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bolge>()
                .Property(e => e.BolgeTanimi)
                .IsFixedLength();

            modelBuilder.Entity<Bolge>()
                .HasMany(e => e.Bolgeler)
                .WithRequired(e => e.Bolge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bolgeler>()
                .Property(e => e.TerritoryTanimi)
                .IsFixedLength();

            modelBuilder.Entity<Bolgeler>()
                .HasMany(e => e.Personeller)
                .WithMany(e => e.Bolgeler)
                .Map(m => m.ToTable("PersonelBolgeler").MapLeftKey("TerritoryID").MapRightKey("PersonelID"));

            modelBuilder.Entity<MusteriDemographics>()
                .Property(e => e.MusteriTypeID)
                .IsFixedLength();

            modelBuilder.Entity<MusteriDemographics>()
                .HasMany(e => e.Musteriler)
                .WithMany(e => e.MusteriDemographics)
                .Map(m => m.ToTable("MusteriMusteriDemo").MapLeftKey("MusteriTypeID").MapRightKey("MusteriID"));

            modelBuilder.Entity<Musteriler>()
                .Property(e => e.MusteriID)
                .IsFixedLength();

            modelBuilder.Entity<Nakliyeciler>()
                .HasMany(e => e.Satislar)
                .WithOptional(e => e.Nakliyeciler)
                .HasForeignKey(e => e.ShipVia);

            modelBuilder.Entity<Personeller>()
                .HasMany(e => e.Personeller1)
                .WithOptional(e => e.Personeller2)
                .HasForeignKey(e => e.BagliCalistigiKisi);

            modelBuilder.Entity<SatisDetay>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satislar>()
                .Property(e => e.MusteriID)
                .IsFixedLength();

            modelBuilder.Entity<Satislar>()
                .Property(e => e.NakliyeUcreti)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satislar>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Satislar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urunler>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urunler>()
                .HasMany(e => e.SatisDetay)
                .WithRequired(e => e.Urunler)
                .WillCascadeOnDelete(false);
        }
    }
}
