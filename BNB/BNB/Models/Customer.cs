using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BNB.Models
{
    public enum PreferredContactMethod
    {
        Phone, Email
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public PreferredContactMethod? ContactMethod { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int BnbID { get; set; }
    }
}