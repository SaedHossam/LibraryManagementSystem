using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}