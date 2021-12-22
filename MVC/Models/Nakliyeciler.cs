namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nakliyeciler")]
    public partial class Nakliyeciler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nakliyeciler()
        {
            Satislar = new HashSet<Satislar>();
        }

        [Key]
        public int NakliyeciID { get; set; }

        [Required]
        [StringLength(40)]
        public string SirketAdi { get; set; }

        [StringLength(24)]
        public string Telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
