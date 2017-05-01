using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Services
{
    public interface IProductsService
    {
        List<Product> GetAllProducts();

        Product GetProduct(int productId);

        List<Product> GetBestSellingProducts();
    }
}
