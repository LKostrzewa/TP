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

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<ProductVendor> productsVendors = dc.GetTable<ProductVendor>();
                List<Product> answer = (from productVendor in productsVendors
                                        where productVendor.Vendor.Name.Equals(vendorName)
                                        select productVendor.Product).ToList();
                return answer;
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using(CatalogDataContext dc = new CatalogDataContext())
            {
                Table<ProductVendor> productVendors = dc.GetTable<ProductVendor>();
                List<string> productsName = (from productVendor in productVendors
                                             where productVendor.Vendor.Name.Equals(vendorName)
                                             select productVendor.Product.Name).ToList();
                return productsName;
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<ProductVendor> productVendors = dc.GetTable<ProductVendor>();
                List<string> vendors = (from productVendor in productVendors
                                        where productVendor.Product.Name.Equals(productName)
                                        select productVendor.Vendor.Name).ToList();
                return vendors[0];
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

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<ProductReview> productReviews = dc.GetTable<ProductReview>();
                List<Product> products = (from productReview in productReviews
                                          orderby productReview.ReviewDate descending
                                          select productReview.Product
                                          ).Take(howManyProducts).ToList();
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
                               where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                               select product.StandardCost).ToList().Sum();
                return (int)sum;
            }
        }
    }
}
