using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class SellingInvoiceItem
    {
        public int Id { get; set; }
        public int SellingInvoiceId { get; set; }
        public virtual SellingInvoice SellingInvoice { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int Quabtity { get; set; }
        public int SubTotal { get; set; }

    }
}