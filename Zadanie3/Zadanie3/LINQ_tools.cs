using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class LINQ_tools
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> productsTable = dc.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.Name.Equals(namePart)
                                          select product).ToList();

                return products;
            }
        }


        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> productsTable = dc.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.ProductReviews.Count == howManyReviews
                                          select product).ToList();

                return products;
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> productsTable = dc.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                          select product).Take(n).ToList();

                return products;
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> productsTable = dc.GetTable<Product>();
                decimal sum = (from product in productsTable
                               where product.ProductSubcategory.ProductCategory.Equals(category)
                               select product.StandardCost).ToList().Sum();
                return (int)sum;
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (CatalogDataContext dataContext = new CatalogDataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<Product> answer = (from productVendor in productsVendors
                                        where productVendor.Vendor.Name.Equals(vendorName)
                                        select productVendor.Product).ToList();
                return answer;
            }
        }
    }
}
