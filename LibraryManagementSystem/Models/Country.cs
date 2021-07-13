using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}