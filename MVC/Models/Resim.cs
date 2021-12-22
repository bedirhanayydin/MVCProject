using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Resim
    {
        [Key]
        public int ID { get; set; }
        public string FotoUrl { get; set; }
    }
}