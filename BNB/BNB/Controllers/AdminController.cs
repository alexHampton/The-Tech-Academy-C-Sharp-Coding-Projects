using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNB.DAL;
using BNB.Models;

namespace BNB.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (BedAndBreakfastContext db = new BedAndBreakfastContext())
            {
                List<Customer> customers = db.Customers.ToList();
                return View(customers);

            }
        }
    }
}