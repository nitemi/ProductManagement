
namespace ProductManagement.Models
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            Product product = context.Products.Find(id);
            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return context.Products;
        }

        public Product GetProduct(int Id)
        {
            return context.Products.Find(Id);
        }

        public Product Update(Product productChanges)
        {
            var product = context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }
      
    }
}
