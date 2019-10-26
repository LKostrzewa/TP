using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            //Assert.AreEqual<Zdarzenie>(ds.WszystkieWydarzeniaDlaKsiazki(10)[1], new Zdarzenie(ds.repository.GetWykaz(2), ds.repository.GetOpisStanu(1), DateTime.Now.AddDays(31)));
        }
    }
}
