using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ReactivitiesContext : DbContext
    {
        public ReactivitiesContext(DbContextOptions options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>().HasData(
                new Value {Id = 1, Name = "Value001"},
                new Value {Id = 2, Name = "Value002"},
                new Value{Id = 3, Name = "Value003"});
        }

        public DbSet<Value> Values { get; set; }
    }
}
