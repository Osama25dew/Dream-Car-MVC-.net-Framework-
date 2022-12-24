using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EADDreamCarProject.Models;

namespace EADDreamCarProject.Controllers
{
    public class BuyCarsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BuyCars
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.CarModel).Include(c => c.Company);
            return View(customers.ToList());
        }

        // GET: BuyCars/Details/5
        public ActionResult Details(int? id)
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

        // GET: BuyCars/Create
        public ActionResult Create()
        {
            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName");
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: BuyCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerPic.SaveAs(Server.MapPath("~/dbPictures/" + customer.CustomerPic.FileName));
                customer.CustomerPicture = "~/dbPictures/" + customer.CustomerPic.FileName;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Client","Home");
            }

            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName", customer.CarModelFID);
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyFID);
            return View(customer);
        }

        // GET: BuyCars/Edit/5
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
            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName", customer.CarModelFID);
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyFID);
            return View(customer);
        }

        // POST: BuyCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,CustomerCity,CustomerAddress,CustomerContact,CustomerEmail,CompanyFID,CarModelFID,CustomerPicture")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName", customer.CarModelFID);
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyFID);
            return View(customer);
        }

        // GET: BuyCars/Delete/5
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

        // POST: BuyCars/Delete/5
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
