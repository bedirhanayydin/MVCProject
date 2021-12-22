

namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int ContactID { get; set; } 
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactComment { get; set; }
    }
}