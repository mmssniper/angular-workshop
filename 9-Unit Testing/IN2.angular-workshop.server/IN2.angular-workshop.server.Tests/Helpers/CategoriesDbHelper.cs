using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN2.angular_workshop.server.Tests.Helpers
{
    public static class CategoriesDbHelper
    {
        public static List<Category> InitForBasicTest()
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
                    }
                };
        }
    }
}
