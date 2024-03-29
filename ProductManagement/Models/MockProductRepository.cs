using System;
using System.Collections.Generic;

namespace ProductManagement.Models
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;
        public MockProductRepository()
        {
            _productList = new List<Product>()
            {
                new Product() { Id = 1, Name = "Sets of Pots", Category = Cate.KitchenUtensils, Description = " 8 sets of pot from mini to maxi" },
                new Product() { Id = 2, Name = "Canadian Beads", Category = Cate.Fashion, Description = "Shinning beads of different colors" },
                new Product() { Id = 3, Name = "Big Bull Rice", Category = Cate.Foodstuffs, Description = "1kg to 50kg available" },
                new Product() { Id = 4, Name = "Lexus", Category = Cate.Cars, Description = "New features" }
            };
        }

        public Product Add(Product product)
        {
            //
            product.Id = _productList.Max(p => p.Id) +1;
            _productList.Add(product);
            return product;
        }

        public Product Delete(int id)
        {
            Product product = _productList.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                _productList.Remove(product);
            }
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productList;
        }

        public Product GetProduct(int Id)
        {
            return _productList.FirstOrDefault(p => p.Id == Id);
        }

        public Product Update(Product productChanges)
        {
            Product product = _productList.FirstOrDefault(p => p.Id == productChanges.Id);
            if (product != null)
            {
                product.Name = productChanges.Name;
                product.Description = productChanges.Description;
                product.Category = productChanges.Category;
            }
            return product;
        }
    }
}