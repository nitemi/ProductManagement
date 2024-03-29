using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProductManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}