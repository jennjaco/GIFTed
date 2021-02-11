using System;
using GIFTed.Models;
using Microsoft.EntityFrameworkCore;

namespace GIFTed.Data
{
    public class ReceiversDbContext : DbContext
    {
        public DbSet<Receivers> Receivers { get; set; }
        public DbSet<Gift> Gift { get; set; }

        public ReceiversDbContext(DbContextOptions<ReceiversDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Gift>()
            //    .HasKey(et => new { et.ReceiversId });
        }
    }
}
