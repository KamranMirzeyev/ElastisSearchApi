using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("User ID=postgres;Password=123;Server=localhost;Port=5432;Database=testDb;Integrated Security=true;Pooling=true;");
        protected override  void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products {get;set;} 
    }
}