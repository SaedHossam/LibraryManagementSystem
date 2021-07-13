using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }
        
        [Display(Name ="Card Number")]
        public int CardNumber { get; set; }

        [Display(Name ="Expire Date")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Display(Name ="Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<BorrowingInvoice> BorrowingInvoices { get; set; }
        public virtual ICollection<SellingInvoice> SellingInvoices { get; set; }
        public virtual ICollection<ReturningInvoice> ReturningInvoices { get; set; }

    }
}