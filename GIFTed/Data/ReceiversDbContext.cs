using System;
using GIFTed.Areas.Identity.Data;
using GIFTed.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GIFTed.Data
{
    public class ReceiversDbContext : IdentityDbContext<GIFTedUser> 
    {
        public DbSet<Receivers> Receivers { get; set; }
        public DbSet<Gift> Gift { get; set; }

        public ReceiversDbContext(DbContextOptions<ReceiversDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
    }
}
