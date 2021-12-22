


namespace MVC.Models
{   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Anasayfa")]

    public partial class Anasayfa
    {   [Key]
        public int AnasayfaID { get; set; }
        public string AnasayfaBaslik { get; set; }

        public string AnasayfaResim { get; set; }

    }
}