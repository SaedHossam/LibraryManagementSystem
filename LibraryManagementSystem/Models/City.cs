using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class City
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}