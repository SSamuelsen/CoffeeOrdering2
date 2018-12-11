using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StephenJoshFinalProject.Models;

namespace StephenJoshFinalProject.Models
{
    public class StephenJoshFinalProjectDbContext : DbContext
    {
        public StephenJoshFinalProjectDbContext (DbContextOptions<StephenJoshFinalProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<StephenJoshFinalProject.Models.User> User { get; set; }

        public DbSet<StephenJoshFinalProject.Models.OrderRequest> OrderRequest { get; set; }

        public DbSet<StephenJoshFinalProject.Models.Order> Order { get; set; }

        public DbSet<StephenJoshFinalProject.Models.DrinkSpecs> DrinkSpecs { get; set; }

        public DbSet<StephenJoshFinalProject.Models.DrinkName> DrinkName { get; set; }

        public DbSet<StephenJoshFinalProject.Models.StoreLogin> StoreLogin { get; set; }

        public DbSet<StephenJoshFinalProject.Models.QueueItem> QueueItem { get; set; }

        public DbSet<StephenJoshFinalProject.Models.CoffeeShopLogin> CoffeeShopLogin { get; set; }



    }
}
