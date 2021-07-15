using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

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

        [Display(Name = "Fine / Day $")]
        public int FinePerDay { get; set; }
    }

    public class BookSelectViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}