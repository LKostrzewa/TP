using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class MyProductTest
    {
        [TestMethod]
        public void GetMyProductsByNameTest()
        {
            List<MyProduct> myProducts = MyProduct_tools.GetMyProductsByName("Decal");
            Assert.AreEqual(myProducts.Count, 2);
            Assert.AreEqual(myProducts[0].ProductNumber, "DC-8732");
        }

        [TestMethod]
        public void GetMyProductsWithNRecentReviewsTest()
        {
            List<MyProduct> myProducts = MyProduct_tools.GetMyProductsWithNRecentReviews(1);
            Assert.AreEqual(myProducts.Count, 2);
            Assert.AreEqual(myProducts[0].ProductNumber, "SO-B909-M");
        }

        /*[TestMethod]
        public void GetNMyProductsFromCategoryTest()
        {
            List<MyProduct> products = MyProduct_tools.GetNMyProductsFromCategory("Bikes", 4);
            Assert.AreEqual(products.Count, 4);
            Assert.AreEqual(products[0].ProductNumber, "BK-M82S-38");
        }*/

        /*[TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory category = new ProductCategory();
            category.Name = "Bikes";
            int sum = MyProduct_tools.GetTotalStandardCostByCategory(category);
            Assert.AreEqual(sum, 92092);
        }*/
    }
}
