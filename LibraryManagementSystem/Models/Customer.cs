using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        // male = true, female = false
        public bool Gender { get; set; }
        
        public string Image { get; set; }
        
        [Display(Name = "Job Title")]
        public int JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<SellingInvoice> SellingInvoices { get; set; }
        public virtual ICollection<BorrowingInvoice> BorrowingInvoices { get; set; }
        public virtual ICollection<ReturningInvoice> ReturningInvoices { get; set; }
    }
}