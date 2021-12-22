namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatisDetay")]
    public partial class SatisDetay
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SatisID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UrunID { get; set; }

        [Column(TypeName = "money")]
        public decimal Fiyat { get; set; }

        public short Adet { get; set; }

        public float Indirim { get; set; }

        public virtual Satislar Satislar { get; set; }

        public virtual Urunler Urunler { get; set; }
    }
}
