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
    public class CarModelsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CarModels
        public ActionResult Index()
        {
            var carModels = db.CarModels.Include(c => c.Company);
            return View(carModels.ToList());
        }

        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                //sab se pehle hum jo col ham ne upload img k liye liya us mai jo img hai usse given path 
                //peh ja k save karwaye ge or Server.MapPath is liye use kiya bcz SaveAs tiled sign ko nai 
                //pehchanta so hame pora path dena pare ga
                carModel.CarModelPic.SaveAs(Server.MapPath("~/dbPictures/" + carModel.CarModelPic.FileName));
                //pher hum nichle mai jo db mai CarModelPicture hai us mai CarModelPic k path ko save karwaye
                //ge
                //is k ilawa hame ek folder b banana pare gaa
                //FileName likhna lazmi hai nahi to file ka name nahi target ho ga
                carModel.CarModelPicture = "~/dbPictures/" + carModel.CarModelPic.FileName;
                db.CarModels.Add(carModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", carModel.CompanyFID);
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", carModel.CompanyFID);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                if (carModel.CarModelPic != null)
                {
                    carModel.CarModelPic.SaveAs(Server.MapPath("~/dbPictures/" + carModel.CarModelPic.FileName));
                    carModel.CarModelPicture = "~/dbPictures/" + carModel.CarModelPic.FileName;
                }
                db.Entry(carModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyFID = new SelectList(db.Companies, "CompanyID", "CompanyName", carModel.CompanyFID);
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = db.CarModels.Find(id);
            db.CarModels.Remove(carModel);
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
