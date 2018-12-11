using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StephenJoshFinalProject.Models
{
    public class StephenJoshFinalProject3Context : DbContext
    {
        public StephenJoshFinalProject3Context (DbContextOptions<StephenJoshFinalProject3Context> options)
            : base(options)
        {
        }

        public DbSet<StephenJoshFinalProject.Models.UserSubmittedOrder> UserSubmittedOrder { get; set; }

        public DbSet<StephenJoshFinalProject.Models.DrinkSpecs> DrinkSpecs { get; set; }

        public DbSet<StephenJoshFinalProject.Models.Order> Order { get; set; }

        public DbSet<StephenJoshFinalProject.Models.User> User { get; set; }

        public DbSet<StephenJoshFinalProject.Models.DrinkName> DrinkName { get; set; }



    }
}
