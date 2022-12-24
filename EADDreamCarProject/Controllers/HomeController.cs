using EADDreamCarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADDreamCarProject.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexCustomer()
        {
            DisplayHomePage dhp=new DisplayHomePage();
            dhp.HomeComp = db.Companies.ToList();
            dhp.HomeCarMod = db.CarModels.ToList();
            dhp.HomeAdm=db.Admins.ToList();
            return View(dhp);
        }

        public ActionResult About()
        {
            return View(db.Admins.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            //please count records from database admin table where table email and password is matched with our posted email and
            //password, if email and password matched result is 1, else result would be 0.
            //Admin a mai jo type kiya data wo ata
            int result = db.Admins.Where(x => x.AdminEmail == a.AdminEmail && x.AdminPassword == a.AdminPassword).Count();
            if (result == 1)
            {
                return RedirectToAction("IndexAdmin", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Email or Password.";
                return View();
            }

        }

        public ActionResult Cart()
        {
            List<CarModel> CarList = new List<CarModel>();
            Session["MyCart"] = CarList;
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            List<CarModel> CarList = new List<CarModel>();
            CarList.Add(db.CarModels.Where(x => x.CarModelID == id).FirstOrDefault());
            Session["MyCart"]=CarList; //yeh hum ne is liye use kiya tah k jo hum ne new list banai jis
                                       //mai specific cart wali gariya hein unhe kisi b page peh use kar
                                       //sake bas is k liye us specific page peh ja k hame Models ko
                                       //declare karna ho ga
            return RedirectToAction("Cart");
        }

        public ActionResult DisplayCarModel(int? id)
        {
            DisplayCar dc = new DisplayCar();
            dc.Comp = db.Companies.ToList();
            if(id==null)
            {
                dc.CarMod = db.CarModels.ToList();
            }
            else
            {
                dc.CarMod = db.CarModels.Where(x=>x.CompanyFID==id).ToList();
            }
            
            return View(dc);
        }

        public ActionResult DisplayShowroom()
        {
            return View(db.Showrooms.ToList());
        }

        public ActionResult Client(int? id)
        {
            DisplayClient dcl = new DisplayClient();
            dcl.CompanyList = db.Companies.ToList();
            if(id == null)
            {
                dcl.CustomerList = db.Customers.ToList();
            }
            else
            {
                dcl.CustomerList = db.Customers.Where(x=>x.CompanyFID==id).ToList();
            }
            
            return View(dcl);
        }

    }
}