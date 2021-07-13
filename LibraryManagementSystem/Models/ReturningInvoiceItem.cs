using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class ReturningInvoiceItem
    {
        public int Id { get; set; }
        public int BorrowingInvoiceItemId { get; set; }
        
        [Required]
        public virtual BorrowingInvoiceItem BorrowingInvoiceItem { get; set; }
        public int LateDays { get; set; }
        public int Fine { get; set; }
    }
}