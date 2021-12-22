namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urunler")]
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            SatisDetay = new HashSet<SatisDetay>();
        }

        [Key]
        public int UrunID { get; set; }

        [Required]
        [StringLength(40)]
        public string UrunAdi { get; set; }

        public int? TedarikciID { get; set; }

        public int? KategoriID { get; set; }

        [StringLength(20)]
        public string BirimdekiMiktar { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fiyat { get; set; }

        public short? Stok { get; set; }

        public short? YeniSatis { get; set; }

        public short? EnAzYenidenSatisMikatari { get; set; }

        public bool Sonlandi { get; set; }
        public string UrunResim { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }

        public virtual Tedarikciler Tedarikciler { get; set; }
    }
}
