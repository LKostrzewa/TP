using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategoryLINQ(this List<Product> products)
        {
            List<Product> answer = (from product in products
                                    where product.ProductSubcategory is null
                                    select product).ToList<Product>();
            return answer;
        }

        public static List<Product> GetProductsWithoutCategory(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList<Product>();
        }

        public static List<List<Product>> DivideProductsOnPages(this List<Product> products, int pageSize, int number)
        {
            List<List<Product>> tmp = new List<List<Product>>();
            for(int i = 0; i < number; i++)
            {
                tmp.Add(products.Skip(i * pageSize).Take(pageSize).ToList());
            }
            return tmp;
        }

        public static string GetProductVendorStringLINQ(this List<Product> products)
        {
            string tmp = "";
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<ProductVendor> productVendors = dc.GetTable<ProductVendor>();
                var answer = (from product in products
                              join productVendor in productVendors on product.ProductID equals productVendor.ProductID
                              where productVendor.ProductID.Equals(product.ProductID)
                              select new { ProductName = product.Name, VendorName = productVendor.Vendor.Name}).ToList();
                foreach(var s in answer)
                {
                    tmp += s.ProductName + "-" + s.VendorName + "\n";
                }
            }
            return tmp;
        }

        public static string GetProductVendorString(this List<Product> products)
        {
            string tmp = "";
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<ProductVendor> productVendors = dc.GetTable<ProductVendor>();
                var answer = products.Join(productVendors,
                                                    product => product.ProductID,
                                                    productVendor => productVendor.ProductID,
                                                    (product, productVendor) => new { ProductName = product.Name, VendorName = productVendor.Vendor.Name }).ToList();
                foreach (var s in answer)
                {
                    tmp += s.ProductName + "-" + s.VendorName + "\n";
                }
            }
            return tmp;
        }
    }
}
