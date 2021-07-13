using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<BorrowingInvoice> BorrowingInvoices { get; set; }
        public virtual ICollection<SellingInvoice> SellingInvoices { get; set; }
        public virtual ICollection<ReturningInvoice> ReturningInvoices { get; set; }
    }
}