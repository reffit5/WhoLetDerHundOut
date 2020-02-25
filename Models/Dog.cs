using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoLetDerHundOut.Models
{
    public class Dog
    {
        public int DogId { get; set; }
        public int UserId { get; set; }
        public string nickName { get; set; }
        public string Breed { get; set; }
        public int BreedId { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
        //public virtual ICollection<Dog> Dogs { get; set; }
        public virtual Users Users { get; set; }
    }
}