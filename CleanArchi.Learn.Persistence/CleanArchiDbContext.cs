using CleanArchi.Learn.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Persistence
{
    public class CleanArchiDbContext : IdentityDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public CleanArchiDbContext(DbContextOptions<CleanArchiDbContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
       .HasMany(c => c.Items)
       .WithOne(e => e.Product)
       .HasForeignKey(e => e.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
