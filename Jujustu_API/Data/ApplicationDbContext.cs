using Jujustu_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jujustu_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Move> Moves { get; set; }

    }
}