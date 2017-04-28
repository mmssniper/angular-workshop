using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Services
{
    public class ProductsService : IProductsService
    {
        List<Product> _products;

        public ProductsService()
        {
            _products = InitAndFill();

        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int productId)
        {
            return _products
                    .Where(x => x.Id == productId)
                    .FirstOrDefault();
        }

        private List<Product> InitAndFill()
        {
            return new List<Product>()
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Album 1",
                        Price = 100.00m,
                        DateCreated = new DateTime(1973,8,1)
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Album 2",
                        Price = 80.00m,
                        DateCreated = new DateTime(2007,10,10)
                    }
                };
        }
    }
}
