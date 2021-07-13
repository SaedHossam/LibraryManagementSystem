using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "No.Of Copies")]
        public int NumberOfCopies { get; set; }

        [Display(Name = "Available")]
        public int AvailableNumberOfCopies { get; set; }

        [Display(Name = "Reservation Price $")]
        public int PriceOfReservation { get; set; }

        [Display(Name = "Reservation Period (Days)")]
        public int ReservationPerieodInDays { get; set; }

        [Display(Name = "Price $")]
        public int PriceOfSelling { get; set; }

        [Display(Name = "Cost $")]
        public int Cost { get; set; }

        [Display(Name = "Fine / Day $")]
        public int FinePerDay { get; set; }

        public virtual ICollection<SellingInvoiceItem> SellingInvoiceItems { get; set; }
        public virtual ICollection<BorrowingInvoiceItem> BorrowingInvoiceItems { get; set; }
    }
}