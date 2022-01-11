using CleanArchi.Learn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Persistence
{
    public class CleanArchiDbContext : DbContext
    {
        public CleanArchiDbContext(DbContextOptions<CleanArchiDbContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
