using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}