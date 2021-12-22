namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MusteriDemographics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MusteriDemographics()
        {
            Musteriler = new HashSet<Musteriler>();
        }

        [Key]
        [StringLength(10)]
        public string MusteriTypeID { get; set; }

        [Column(TypeName = "ntext")]
        public string MusteriDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteriler> Musteriler { get; set; }
    }
}
