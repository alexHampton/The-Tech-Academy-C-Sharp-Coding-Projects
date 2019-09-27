using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BNB.Models;

namespace BNB.DAL
{
    // Was used to try to Initialize Bnbs Table with default data. Didn't work.
    //public class BedAndBreakfastInitializer:CreateDatabaseIfNotExists<BedAndBreakfastContext>
    //{
    //    protected override void Seed(BedAndBreakfastContext context)
    //    {
    //        IList<Bnb> Bnbs = new List<Bnb>();
    //        Bnbs.Add(new Bnb() { Name = "Country Gardens", Address = "4236 Garden Path" });
    //        Bnbs.Add(new Bnb() { Name = "Country Roads", Address = "12 Main Street" });
    //        Bnbs.Add(new Bnb() { Name = "Country Hills", Address = "1 Private Way" });


    //        context.Bnbs.AddRange(Bnbs);
    //        context.SaveChanges();

    //        base.Seed(context);
    //    }
    //}
}