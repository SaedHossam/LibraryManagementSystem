using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}