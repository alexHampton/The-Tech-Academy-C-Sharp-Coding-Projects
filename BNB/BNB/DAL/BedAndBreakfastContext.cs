using BNB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BNB.DAL
{
    //This is the database
    public class BedAndBreakfastContext : DbContext // Inherits from DbContext
    {
        // Name of the connection string
        public BedAndBreakfastContext() : base("BedAndBreakfastContext")
        {
            // Was used to try to Initialize Bnbs Table with default data. 
            // Didn't work.
            //Database.SetInitializer(new BedAndBreakfastInitializer());
        }
        
        // Entity Sets (DB Tables)
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bnb> Bnbs { get; set; }
    }
}