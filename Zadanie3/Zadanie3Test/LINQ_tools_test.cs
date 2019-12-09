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
    }
}
