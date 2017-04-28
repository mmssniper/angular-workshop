using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        List<Product> GetProductsForCategory(int categoryId);
    }
}
