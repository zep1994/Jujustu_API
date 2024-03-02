using Microsoft.EntityFrameworkCore;
using System;

namespace Jujustu_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<YourModel> YourModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YourModel>().ToTable("YourTableName");
        }
    }