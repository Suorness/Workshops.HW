using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DebuggingApp.Models
{
    public class CarDbInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Cars.Add(new Car { Name = "Название 1", Price = 20 });
            db.Cars.Add(new Car { Name = "Название 2", Price = 18 });
            db.Cars.Add(new Car { Name = "Название 3", Price = 15 });

            base.Seed(db);
        }
    }
}