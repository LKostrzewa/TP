using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3;

namespace Zadanie3Test
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void GetProductsWithoutCategoryTest()
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                List<Product> list = dc.GetTable<Product>().ToList();
                List<Product> resLINQ = list.GetProductsWithoutCategoryLINQ();
                List<Product> res = list.GetProductsWithoutCategory();

                Assert.AreEqual(res.Count(), 209);
                Assert.AreEqual(resLINQ.Count(), 209);
                Assert.AreEqual(resLINQ[2].ProductNumber, res[2].ProductNumber);
                Assert.AreEqual(resLINQ[2], res[2]);
                Assert.AreEqual(res[2].ProductNumber, "BE-2349");
            }
        }

        [TestMethod]
        public void GetProductVendorStringTest()
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                List<Product> list = dc.GetTable<Product>().ToList();
                string resLINQ = list.GetProductVendorStringLINQ();
                string res = list.GetProductVendorString();

                string lineLINQ = resLINQ.Split('\n')[2];
                string line = res.Split('\n')[2];

                Assert.AreEqual(line, lineLINQ);
                Assert.AreEqual(line, "Headset Ball Bearings-American Bicycles and Wheels");
            }
        }

        [TestMethod]
        public void DivideProductsOnPagesTest()
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                List<Product> list = dc.GetTable<Product>().ToList();
                List<List<Product>> res = list.DivideProductsOnPages(5, 5);

                Assert.AreEqual(res.Count(), 5);
                Assert.AreEqual(res[0].Count(), 5);
            }
        }
    }
}
