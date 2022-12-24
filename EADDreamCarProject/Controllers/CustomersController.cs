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
    public class CustomersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.CarModel).Include(c => c.Company);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
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

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName");
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //sab se pehle hum jo col ham ne upload img k liye liya us mai jo img hai usse given path 
                //peh ja k save karwaye ge or Server.MapPath is liye use kiya bcz SaveAs tiled sign ko nai 
                //pehchanta so hame pora path dena pare ga
                customer.CustomerPic.SaveAs(Server.MapPath("~/dbPictures/" + customer.CustomerPic.FileName));
                //pher hum nichle mai jo db mai dbPictures hai us mai CustomerPic k path ko save karwaye
                //ge
                //is k ilawa hame ek folder b banana pare gaa
                //FileName likhna lazmi hai nahi to file ka name nahi target ho ga
                customer.CustomerPicture = "~/dbPictures/" + customer.CustomerPic.FileName;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName", customer.CarModelFID);
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyFID);
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
            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName", customer.CarModelFID);
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyFID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerPic != null)
                {
                    customer.CustomerPic.SaveAs(Server.MapPath("~/dbPictures/" + customer.CustomerPic.FileName));
                    customer.CustomerPicture = "~/dbPictures/" + customer.CustomerPic.FileName;
                }
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarModelFID = new SelectList(db.CarModels, "CarModelID", "CarModelName", customer.CarModelFID);
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", customer.CompanyFID);
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
