using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HipermarketApp.Models;
using HipermarketApp.ViewModels;

namespace HipermarketApp.Data
{
    public class HipermarketAppContext : DbContext
    {
        public HipermarketAppContext (DbContextOptions<HipermarketAppContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.SafetyStock)
                .HasDefaultValue(0);

            modelBuilder.Entity<ProductsSupplierDetails>().HasKey(x => new { x.ProductID, x.SupplierID });
        }



        public DbSet<HipermarketApp.Models.Category> Categories { get; set; }
        public DbSet<HipermarketApp.Models.Product> Products { get; set; }
        public DbSet<HipermarketApp.Models.Supplier> Suppliers { get; set; }
        public DbSet<HipermarketApp.Models.Zone> Zones { get; set; }
        public DbSet<HipermarketApp.Models.Location> Location { get; set; }
        public DbSet<HipermarketApp.Models.ProductsSupplierDetails> ProductsSupplierDetails { get; set; }


        
    }
}
