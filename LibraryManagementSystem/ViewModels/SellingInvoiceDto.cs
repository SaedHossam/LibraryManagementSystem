using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.ViewModels
{
    public class SellingInvoiceDto
    {

        public int Id { get; set; }
        public string Customer { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name ="Sub Total $")]
        public int SubTotal { get; set; }
        [Display(Name = "Discount %")]
        public int Discount { get; set; }
        [Display(Name = "Sub Total $")]
        public int Total { get; set; }
        //public ICollection<SellingInvoiceItemDto> Items { get; set; }

    }

    public class SellingInvoiceItemDto
    {
        public int Id { get; set; }
        //public int SellingInvoiceId { get; set; }
        public int BookId { get; set; }
        public string Book { get; set; }
        public int Quabtity { get; set; }
        public int SubTotal { get; set; }
    }

    public class SellingInvoiceCreateDto
    {
        public SellingInvoiceCreateDto()
        {
            Items = new List<SellingInvoiceItemCreateDto>();
        }

        public int CustomerId { get; set; }
        public int SubTotal { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        public List<SellingInvoiceItemCreateDto> Items { get; set; }
    }

    public class SellingInvoiceItemCreateDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }
    }
}