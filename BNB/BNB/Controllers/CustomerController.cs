using BNB.DAL;
using BNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNB.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertDB(string firstName, string lastName, string phone,
            string email, PreferredContactMethod? contactMethod, DateTime checkIn, 
            DateTime checkOut, int BnbID)
        {
            using (BedAndBreakfastContext db = new BedAndBreakfastContext())
            {
                // This was used to initialize BNBs once when the program ran. 
                // Now that they are created, this code is no longer needed.
                //var defaultbnb1 = new Bnb() { Name = "Country Gardens", Address = "4236 Garden Path" };
                //var defaultbnb2 = new Bnb() { Name = "Country Roads", Address = "12 Main Street" };
                //var defaultbnb3 = new Bnb() { Name = "Country Hills", Address = "1 Private Way" };

                //db.Bnbs.Add(defaultbnb1);
                //db.Bnbs.Add(defaultbnb2);
                //db.Bnbs.Add(defaultbnb3);
                //db.SaveChanges();

                var customer = new Customer();
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.Phone = phone;
                customer.Email = email;
                customer.ContactMethod = contactMethod;
                customer.CheckIn = checkIn;
                customer.CheckOut = checkOut;
                customer.BnbID = BnbID;

                db.Customers.Add(customer);
                db.SaveChanges();

                return View("Success");
            }
        }
    }
}