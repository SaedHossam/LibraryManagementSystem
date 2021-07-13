using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BorrowingInvoice : BasicInvoice
    {
        public virtual ICollection<BorrowingInvoiceItem> BorrowingInvoiceItems { get; set; }
    }
}