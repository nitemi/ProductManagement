namespace ProductManagement.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetAllProduct();
        Product Add(Product product);
        Product Update(Product productChanges);
        Product Delete(int id);
    }
}
