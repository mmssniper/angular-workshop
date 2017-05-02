using IN2.angular_workshop.server.Models;
using IN2.angular_workshop.server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Tests.Helpers
{
    public class DummyProductsService : IProductsService
    {
        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetBestSellingProducts()
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
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Album 3",
                        Price = 80.00m,
                        DateCreated = new DateTime(2007,10,10)
                    }
            };
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
