using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class MyProduct_tools
    {
        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            using (MyProductDataContext dc = new MyProductDataContext(new CatalogDataContext()))
            {
                List<MyProduct> myProduct = (from product in dc.myProducts
                                             where product.Name.Contains(namePart)
                                             select product).ToList();
                return myProduct;
            }

        }

        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            using (MyProductDataContext dc = new MyProductDataContext(new CatalogDataContext()))
            {
                List<MyProduct> myProduct = (from product in dc.myProducts
                                             where product.ProductReviews.Count == howManyReviews
                                             select product).ToList();

                return myProduct;
            }
        }


        public static List<MyProduct> GetNMyProductsFromCategory(string categoryName, int n)
        {
            using (MyProductDataContext dc = new MyProductDataContext(new CatalogDataContext()))
            {
                List<MyProduct> myProducts = (from product in dc.myProducts
                                              where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                              orderby product.ProductSubcategory.Name 
                                              select product).Take(n).ToList();

                return myProducts;
            }
        }
    }
}
