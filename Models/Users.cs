using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoLetDerHundOut.Models
{
    public class Users
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int NumberofDogs  { get; set; }
        public int DogId { get; set; }
       
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}