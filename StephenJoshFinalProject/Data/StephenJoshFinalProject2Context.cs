using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;

namespace StephenJoshFinalProject.Models
{
    public class StephenJoshFinalProject2Context : DbContext
    {
        public StephenJoshFinalProject2Context (DbContextOptions<StephenJoshFinalProject2Context> options)
            : base(options)
        {
        }

        public DbSet<StephenJoshFinalProject.Models.CoffeeShopLogin> CoffeeShopLogin { get; set; }

        public DbSet<StephenJoshFinalProject.Models.UserSubmittedOrder> UserSubmittedOrder { get; set; }


        public DbSet<StephenJoshFinalProject.Models.User> User { get; set; }

        public DbSet<StephenJoshFinalProject.Models.OrderRequest> OrderRequest { get; set; }

        public DbSet<StephenJoshFinalProject.Models.Order> Order { get; set; }

        public DbSet<StephenJoshFinalProject.Models.DrinkSpecs> Specs { get; set; }

        public DbSet<StephenJoshFinalProject.Models.DrinkName> Drinks { get; set; }

    }
}
