using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IN2.angular_workshop.server.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}