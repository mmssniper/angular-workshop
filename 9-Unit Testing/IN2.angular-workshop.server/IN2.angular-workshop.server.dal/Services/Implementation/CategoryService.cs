using IN2.angular_workshop.server.dal;
using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Services
{
    public class CategoryService : ICategoryService
    {
        List<Category> _categories;
        ShopContext _dbContext;

        public CategoryService()
        {
            _categories = InitAndFill();

        }

        public CategoryService(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CategoryService(List<Category> categories)
        {
            _categories = categories;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _dbContext.Categories
                    .Where(x => x.Id == categoryId)
                    .FirstOrDefault();
        }

        public List<Product> GetProductsForCategory(int categoryId)
        {
            var category = _dbContext.Categories
                            .Where(x => x.Id == categoryId)
                            .FirstOrDefault();

            if (category == null)
                return null;

            return category.Products;
        }

        public Category Save(Category category)
        {
            if (category.Id == 0)
            {
                _dbContext.Categories.Add(category);
                _dbContext.Entry<Category>(category).State = EntityState.Added;
            }
            else
            {

                _dbContext.Entry<Category>(category).State = EntityState.Modified;


            }

            _dbContext.SaveChanges();

            return category;
        }


        private List<Category> InitAndFill()
        {
             return new List<Category>()
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Jazz"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Rock"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Classic"
                    },
                    new Category
                    {
                        Id  = 4,
                        Name = "Modern"
                    }
                };
        }
    }
}
