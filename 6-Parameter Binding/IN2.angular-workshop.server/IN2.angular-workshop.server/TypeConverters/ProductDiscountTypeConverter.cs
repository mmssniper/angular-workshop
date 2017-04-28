using IN2.angular_workshop.server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IN2.angular_workshop.server.TypeConverters
{
    public class ProductDiscountTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            if (value is string)
            {
                ProductDiscount discountInstance;

                if (ProductDiscount.TryParse((string)value, out discountInstance))
                {
                    return discountInstance;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}