using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoLetDerHundOut.Models
{
    public class Breed
    {
         [Display (Name ="Breed ID")]
        public int BreedId { get; set; }
        public string BreedName { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}