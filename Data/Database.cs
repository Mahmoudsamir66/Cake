using Cake.Data.Configuration;
using Cake.Data.Configurations;
using Cake.Models;
using Microsoft.EntityFrameworkCore;

namespace Cake.Data
{
    public class Database:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CakeDataBase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration()).Seed();
        }

    }
}
