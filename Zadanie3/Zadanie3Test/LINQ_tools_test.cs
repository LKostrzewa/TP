using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class LINQ_tools_test
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = LINQ_tools.GetProductsByName("Down Tube");
            Assert.AreEqual(products.Count(), 1);
            Assert.AreEqual(products[0].ProductNumber, "DT-2377");
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = LINQ_tools.GetProductsByVendorName("Australia Bike Retailer");
            Assert.AreEqual(products.Count(), 16);
            Assert.AreEqual(products[0].ProductNumber, "LJ-1213");
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> products = LINQ_tools.GetProductNamesByVendorName("Australia Bike Retailer");
            Assert.AreEqual(products.Count(), 16);
            Assert.AreEqual(products[0], "Thin-Jam Lock Nut 9");
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendors = LINQ_tools.GetProductVendorByProductName("Decal 2");
            Assert.AreEqual(vendors, "SUPERSALES INC.");
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = LINQ_tools.GetProductsWithNRecentReviews(5);
            Assert.AreEqual(products.Count(), 0);
        }
    }
}
