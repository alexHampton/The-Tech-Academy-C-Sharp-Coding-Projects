using CarInsuranceQuote.Models;
using CarInsuranceQuote.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuote.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (Car_Insurance_QuoteEntities db = new Car_Insurance_QuoteEntities())
            {
                List<Quote> quotes = db.Quotes.ToList(); // Creates a List of all quotes from the DB.

                var quoteVMs = new List<QuoteVM>(); // Instantiates a View Model List, DB info is mapped into it.
                // Maps pertinent info from the DB to the View Model.
                foreach (var quote in quotes)
                {
                    QuoteVM quoteVM = new QuoteVM();
                    quoteVM.FirstName = quote.FirstName;
                    quoteVM.LastName = quote.LastName;
                    quoteVM.Email = quote.Email;
                    quoteVM.Total = quote.Total;

                    quoteVMs.Add(quoteVM); // Add the quote into the View Model.
                }

                return View(quoteVMs);
            }
        }
    }
}