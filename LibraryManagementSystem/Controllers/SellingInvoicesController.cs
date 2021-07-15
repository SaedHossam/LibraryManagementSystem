using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    public class SellingInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SellingInvoices
        [AllowAnonymous]
        public ActionResult Index()
        {
            var sellingInvoices = db.SellingInvoices.Include(s => s.Customer).OrderBy(i => i.Date).ToList();
            var list = new List<SellingInvoiceDto>();
            foreach (var i in sellingInvoices)
            {
                list.Add(new SellingInvoiceDto()
                {
                    Id = i.Id,
                    Customer = i.Customer.Name,
                    Date = i.Date,
                    Discount = i.Discount,
                    Total = i.Total,
                    SubTotal = i.SubTotal
                });
            }
            return View(list);
        }

        // GET: SellingInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingInvoice sellingInvoice = db.SellingInvoices.Find(id);
            if (sellingInvoice == null)
            {
                return HttpNotFound();
            }
            return View(sellingInvoice);
        }

        // GET: SellingInvoices/Create
        public ActionResult Create()
        {
            //ViewBag.CreditCardId = new SelectList(db.CreditCards, "Id", "CardHolderName");
            //ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "Id", "Name");
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            var customers = new List<CustomerSelectViewModel>();
            foreach(var c in db.Customers)
            {
                customers.Add(new CustomerSelectViewModel() { 
                Id = c.Id,
                Name = c.Name
                });
            }
            var books = new List<BookSelectViewModel>();
            foreach(var b in db.Books)
            {
                books.Add(new BookSelectViewModel() { 
                Id = b.Id,
                Name = b.Name,
                Price = b.PriceOfSelling
                });
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name");
            ViewBag.Customers = customers;
            ViewBag.Books = books;
            ViewBag.Date = DateTime.Today.ToShortDateString();
            return View();
        }

        // POST: SellingInvoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(SellingInvoiceCreateDto sellingInvoice)
        {
            if (ModelState.IsValid)
            {
                // TODO: Change Payment Method
                var invoice = new SellingInvoice() {
                    CustomerId = sellingInvoice.CustomerId,
                    Date = DateTime.Today,
                    SubTotal = sellingInvoice.SubTotal,
                    Discount = sellingInvoice.Discount,
                    Total = sellingInvoice.Total,
                    PaymentMethodId = 1
                };
                db.SellingInvoices.Add(invoice);
                db.SaveChanges();
                invoice.SellingInvoiceItems = new List<SellingInvoiceItem>();
                foreach(var i in sellingInvoice.Items)
                {
                    var item = new SellingInvoiceItem() { 
                        SellingInvoiceId = invoice.Id,
                        BookId = i.BookId,
                        Quantity = i.Quantity,
                        SubTotal = i.SubTotal
                    };
                    invoice.SellingInvoiceItems.Add(item);

                    // update Book Avalible copies
                    var book = db.Books.Find(i.BookId);
                    book.AvailableNumberOfCopies -= i.Quantity;
                    db.SaveChanges();
                }
                //return RedirectToAction("Create");
                return JavaScript("window.location = '" + Url.Action("Index", "SellingInvoices") + "'");
            }

            var customers = new List<CustomerSelectViewModel>();
            foreach (var c in db.Customers)
            {
                customers.Add(new CustomerSelectViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                });
            }
            var books = new List<BookSelectViewModel>();
            foreach (var b in db.Books)
            {
                books.Add(new BookSelectViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.PriceOfSelling
                });
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name");
            ViewBag.Customers = customers;
            ViewBag.Books = books;
            ViewBag.Date = DateTime.Today.ToShortDateString();
            return View(sellingInvoice);
        }

        // GET: SellingInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingInvoice sellingInvoice = db.SellingInvoices.Find(id);
            if (sellingInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreditCardId = new SelectList(db.CreditCards, "Id", "CardHolderName", sellingInvoice.CreditCardId);
            ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "Id", "Name", sellingInvoice.PaymentMethodId);
            return View(sellingInvoice);
        }

        // POST: SellingInvoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CusomerId,Date,SubTotal,Discount,Total,PaymentMethodId,CreditCardId")] SellingInvoice sellingInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellingInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreditCardId = new SelectList(db.CreditCards, "Id", "CardHolderName", sellingInvoice.CreditCardId);
            ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "Id", "Name", sellingInvoice.PaymentMethodId);
            return View(sellingInvoice);
        }

        // GET: SellingInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingInvoice sellingInvoice = db.SellingInvoices.Find(id);
            if (sellingInvoice == null)
            {
                return HttpNotFound();
            }
            return View(sellingInvoice);
        }

        // POST: SellingInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellingInvoice sellingInvoice = db.SellingInvoices.Find(id);
            db.SellingInvoices.Remove(sellingInvoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public bool IsQuantityAvailable(int bookId, int quantity)
        {
            var res = db.Books.Where(b => b.Id == bookId).FirstOrDefault().AvailableNumberOfCopies >= quantity;
            return res;
        }
    }
}
