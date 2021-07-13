using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class ReturningInvoice : BasicInvoice
    {
        public virtual ICollection<ReturningInvoiceItem> ReturningInvoiceItems { get; set; }
    }
}