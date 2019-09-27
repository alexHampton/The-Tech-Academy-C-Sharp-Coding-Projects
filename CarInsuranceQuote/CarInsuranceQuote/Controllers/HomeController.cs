using CarInsuranceQuote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuote.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Takes in user input, calculates a quote, and adds data to DB.
        [HttpPost]
        public ActionResult GetQuote(string firstName, string lastName, string email,
            DateTime dateOfBirth, int carYear, string carMake, string carModel,
            bool dui, int ticketNumber, bool fullCoverage)
        {
            using (Car_Insurance_QuoteEntities db = new Car_Insurance_QuoteEntities())
            {
                // Maps user input to DB.
                var quote = new Quote();
                quote.FirstName = firstName;
                quote.LastName = lastName;
                quote.Email = email;
                quote.DateOfBirth = dateOfBirth;
                quote.CarYear = carYear;
                quote.CarMake = carMake;
                quote.CarModel = carModel;
                quote.DUI = dui;
                quote.TicketNumber = ticketNumber;
                quote.FullCoverage = fullCoverage;
                quote.Total = CalcQuote(quote); //Quote total is calulated.

                db.Quotes.Add(quote); //Data added to DB.
                db.SaveChanges(); // Data saved to DB

                return View(quote);
            }
        }

        // Calculates user quote.
        private decimal CalcQuote(Quote quote)
        {
            decimal total = 50m; // base of $50

            TimeSpan timespan = DateTime.Now - quote.DateOfBirth;
            int years = Convert.ToInt32(timespan.Days) / 365;
            if (years < 25)
            {
                if (years < 18) total += 100; // Add 100 if under 18 years old.
                else total += 25; // Add 25 if under 25 but over 18 years old.
            }
            if (years > 100) total += 25; // Add $25 if over 100 years old.

            if (quote.CarYear < 2000 || quote.CarYear > 2015) total += 25; // Add $25 if car older than 2000 or newer than 2015.

            if (quote.CarMake.ToLower() == "porsche")
            {
                total += 25; // Add $25 if car is a Porsche.
                if (quote.CarModel.ToLower() == "911 carrera") total += 25; // Add another $25 if Porsche is a 911 Carrera.
            }
            for (int i = 0; i < quote.TicketNumber; i++)
            {
                total += 10; //Add $10 for every speeding ticket.
            }
            if (quote.DUI) total = total * 1.25m; // Add 25% if they have a DUI.
            if (quote.FullCoverage) total = total * 1.5m; // Add 50% for Full Coverage.

            total = Decimal.Ceiling(total * 100); //Ensure total is rounded up.
            total = total / 100; // Ensure total only shows two decimal places.
                                 
            return total;
        }
    }
}