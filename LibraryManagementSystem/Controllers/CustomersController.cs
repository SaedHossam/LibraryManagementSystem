using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.City).Include(c => c.Country).Include(c => c.JobTitle);

            var list = new List<CustomerViewModel>();
            foreach(var c in customers)
            {
                list.Add(new CustomerViewModel() {
                    Id = c.Id,
                    City = c.City.Name,
                    Country = c.Country.Name,
                    Gender = c.Gender == true? "Male" : "Female",
                    Email = c.Email,
                    DateOfBirth = c.DateOfBirth,
                    Name = c.Name,
                    Phone = c.Phone,
                    JobTitle = c.JobTitle.Name
                });
            }
            return View(list);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer c = db.Customers.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            var customer = new CustomerDetailsViewModel() {
                Id = c.Id,
                City = c.City.Name,
                Country = c.Country.Name,
                Gender = c.Gender == true ? "Male" : "Female",
                Email = c.Email,
                DateOfBirth = c.DateOfBirth,
                Name = c.Name,
                Phone = c.Phone,
                JobTitle = c.JobTitle.Name,
                Image = c.Image
            };
            ViewBag.Image = c.Image;
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                // TODO: Change Image Name to new GUID + image extention
                string FileName = ImageFile.FileName;
                // string Name = Guid.NewGuid().ToString();
                string Path = "~/Resources/images/" + FileName;
                ImageFile.SaveAs(Server.MapPath(Path));
                customer.Image = Path;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customer.CountryId);
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", customer.JobTitleId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            //customer.DateOfBirth = customer.DateOfBirth;
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customer.CountryId);
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", customer.JobTitleId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Image,JobTitleId,DateOfBirth,Email,Phone,CountryId,CityId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customer.CountryId);
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "Id", "Name", customer.JobTitleId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
    }
}
