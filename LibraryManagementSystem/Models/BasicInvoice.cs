using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BasicInvoice
    {
        public int Id { get; set; }

        [Display(Name ="Customer Name")]
        public int CusomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int SubTotal { get; set; }

        [Display(Name ="Discount %")]
        public int Discount { get; set; }
        public int Total { get; set; }

        [Display(Name ="Payment Method")]
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public int? CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}