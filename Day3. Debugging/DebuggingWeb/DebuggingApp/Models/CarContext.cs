using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DebuggingApp.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}