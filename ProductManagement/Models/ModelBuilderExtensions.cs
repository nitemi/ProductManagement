using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "GoldenPenny Semovita",
                Description = "10kgbag containing 1kg each of semovita",
                Category = Cate.Foodstuffs,
            },

                new Product
                {
                    Id = 2,
                    Name = "HoneyWell Semovita",
                    Description = "20kgbag containing 500g each of semovita",
                    Category = Cate.Foodstuffs,


                });
        }
    }
}
