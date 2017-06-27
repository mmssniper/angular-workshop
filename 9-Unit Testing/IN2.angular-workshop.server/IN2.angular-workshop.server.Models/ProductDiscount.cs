
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IN2.angular_workshop.server.Models
{
    //[TypeConverter(typeof(ProductDiscountTypeConverter))]
    public class ProductDiscount
    {
        public int ProductId { get; set; }
        public decimal DiscountPrice { get; set; }

        public static bool TryParse(string s, out ProductDiscount result)
        {
            result = null;

            var parts = s.Split(',');
            if (parts.Length != 2)
            {
                return false;
            }

            int id = 0;
            decimal discountPrice = 0.0m;

            if (int.TryParse(parts[0], out id) &&
                decimal.TryParse(parts[1], out discountPrice))
            {
                result = new ProductDiscount() { ProductId = id, DiscountPrice = discountPrice };
                return true;
            }

            return false;
        }

    }
}