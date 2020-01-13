using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class LINQ_tools
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> productsTable = dc.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.Name.Contains(namePart)
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

        public static void InsertNewProduct(Product product)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                product.ModifiedDate = DateTime.Now;
                product.rowguid = Guid.NewGuid();
                dc.Products.InsertOnSubmit(product);
                dc.SubmitChanges();
            }
        }

        public static Product GetProductById(int id)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                return dc.GetTable<Product>().SingleOrDefault(p => p.ProductID.Equals(id));
            }
        }

        public static IEnumerable<Product> GetAllProducts()
        {
            using(CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> products = dc.GetTable<Product>();
                IQueryable<Product> answer = (from product in products
                                              select product);
                return answer.ToList();
            }
        }

        public static void DeleteProductId(int id)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                var answer = dc.GetTable<Product>().First(e => e.ProductID == id);
                dc.Products.DeleteOnSubmit(answer);
                dc.SubmitChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                var originalProduct = dc.GetTable<Product>().SingleOrDefault(p => p.ProductID.Equals(product.ProductID));
                originalProduct.Name = product.Name;
                originalProduct.ProductNumber = product.ProductNumber;
                originalProduct.MakeFlag = product.MakeFlag;
                originalProduct.FinishedGoodsFlag = product.FinishedGoodsFlag;
                originalProduct.Color = product.Color;
                originalProduct.SafetyStockLevel = product.SafetyStockLevel;
                originalProduct.ReorderPoint = product.ReorderPoint;
                originalProduct.StandardCost = product.StandardCost;
                originalProduct.ListPrice = product.ListPrice;
                originalProduct.Size = product.Size;
                originalProduct.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                originalProduct.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                originalProduct.Weight = product.Weight;
                originalProduct.DaysToManufacture = product.DaysToManufacture;
                originalProduct.ProductLine = product.ProductLine;
                originalProduct.Class = product.Class;
                originalProduct.Style = product.Style;
                originalProduct.ProductSubcategoryID = product.ProductSubcategoryID;
                originalProduct.ProductModelID = product.ProductModelID;
                originalProduct.SellStartDate = product.SellStartDate;
                originalProduct.SellEndDate = product.SellEndDate;
                originalProduct.DiscontinuedDate = product.DiscontinuedDate;
                originalProduct.ModifiedDate = DateTime.Today;
                dc.SubmitChanges();

            }
        }
    }
}
