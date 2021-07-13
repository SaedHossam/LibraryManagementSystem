using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BorrowingInvoiceItem
    {
        public int Id { get; set; }
        public int BorrowingInvoiceId { get; set; }
        public virtual BorrowingInvoice BorrowingInvoice { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public bool IsReturned { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public int SubTotal { get; set; }
        public int? ReturningInvoiceItemId { get; set; }
        public virtual ReturningInvoiceItem ReturningInvoiceItem { get; set; }

    }
}