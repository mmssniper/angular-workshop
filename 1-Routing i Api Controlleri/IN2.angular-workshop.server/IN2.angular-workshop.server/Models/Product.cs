using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IN2.angular_workshop.server.Models
{
    /// <summary>
    /// Product POCO class
    /// </summary>
    public class Product
    {
        public Product()
        {
            this.DateCreated = null;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
    }
}