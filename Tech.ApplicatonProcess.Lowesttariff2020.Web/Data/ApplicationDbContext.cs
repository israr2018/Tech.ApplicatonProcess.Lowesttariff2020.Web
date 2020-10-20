using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tech.ApplicatonProcess.Lowesttariff2020.Web.Model;

namespace Tech.ApplicatonProcess.Lowesttariff2020.Web.Data
{
    public class ApplicationDbContext:DbContext
    { 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Application> Applications { get; set; }

    }

}

