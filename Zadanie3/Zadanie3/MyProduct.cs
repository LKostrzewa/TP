using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProduct : Product
    {
        public MyProduct(Product product)
        {
            /*Name = product.Name;
            ListPrice = product.ListPrice;
            ProductReviews = product.ProductReviews;
            ProductNumber = product.ProductNumber;
            ProductSubcategory = product.ProductSubcategory;*/
            foreach (var property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(product));
            }
        }
    }
}
