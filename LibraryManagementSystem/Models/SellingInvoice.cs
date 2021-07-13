using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class SellingInvoice : BasicInvoice
    {
        public virtual ICollection<SellingInvoiceItem> SellingInvoiceItems { get; set; }
        
    }
}