using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class CrudTests
    {

        [TestMethod]
        public void TestTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());
            repo.GetKatalog(10);
            //repo.GetKatalog(11);

        }
    }
}
