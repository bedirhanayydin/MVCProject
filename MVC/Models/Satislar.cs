namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Satislar")]
    public partial class Satislar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Satislar()
        {
            SatisDetay = new HashSet<SatisDetay>();
        }

        [Key]
        public int SatisID { get; set; }

        [StringLength(5)]
        public string MusteriID { get; set; }

        public int? PersonelID { get; set; }

        public DateTime? SatisTarihi { get; set; }

        public DateTime? OdemeTarihi { get; set; }

        public DateTime? SevkTarihi { get; set; }

        public int? ShipVia { get; set; }

        [Column(TypeName = "money")]
        public decimal? NakliyeUcreti { get; set; }

        [StringLength(40)]
        public string SevkAdi { get; set; }

        [StringLength(60)]
        public string SevkAdresi { get; set; }

        [StringLength(15)]
        public string SevkSehri { get; set; }

        [StringLength(15)]
        public string SevkBolgesi { get; set; }

        [StringLength(10)]
        public string SevkPostaKodu { get; set; }

        [StringLength(15)]
        public string SevkUlkesi { get; set; }

        public virtual Musteriler Musteriler { get; set; }

        public virtual Nakliyeciler Nakliyeciler { get; set; }

        public virtual Personeller Personeller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }
    }
}
