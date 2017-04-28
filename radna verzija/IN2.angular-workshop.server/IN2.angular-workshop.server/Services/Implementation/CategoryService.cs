﻿using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Services
{
    public class CategoryService : ICategoryService
    {
        List<Category> _categories;

        public CategoryService()
        {
            _categories = InitAndFill();

        }
        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public List<Product> GetProductsForCategory(int categoryId)
        {
            var category = _categories
                            .Where(x => x.Id == categoryId)
                            .FirstOrDefault();

            if (category == null)
                return null;

            return category.Products;
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