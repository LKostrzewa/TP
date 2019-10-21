using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class RepositoryTest
    {

        [TestMethod]
        public void KatalogTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Katalog katTest = new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100);

            Assert.AreEqual<Katalog>(repo.GetKatalog(10), katTest);

            Katalog katTest2 = new Katalog(50, "Jezyk C#", "Podrecznik", 500);

            repo.AddKatalog(katTest2);
            Assert.AreEqual<Katalog>(repo.GetKatalog(50), katTest2);
            Assert.AreEqual<int>(repo.GetAllKatalog().Count(), 5);

            Katalog katTest3 = new Katalog(60, "Spring w akcji", "Podrecznik", 600);

            repo.UpdateKatalog(50, katTest3);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetKatalog(50));
            Assert.AreEqual(repo.GetKatalog(60), katTest3);

            repo.DeleteKatalog(katTest3);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetKatalog(60));
            Assert.AreEqual<int>(repo.GetAllKatalog().Count(), 4);
        }

        [TestMethod]
        public void OpisStanuTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Katalog katTest = new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100);
            OpisStanu opisTest = new OpisStanu(0, katTest, new DateTime(2019, 10, 5), 10, 29, 5);

            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(0), opisTest);

            OpisStanu opisTest2 = new OpisStanu(2, katTest, new DateTime(2019, 10, 21), 2, 40, 15);

            repo.AddOpisStanu(opisTest2);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(2), opisTest2);
            Assert.AreEqual<int>(repo.GetAllOpisStanu().Count(), 3);

            OpisStanu opisTest3 = new OpisStanu(3, katTest, new DateTime(2019, 10, 15), 20, 80, 20);

            repo.UpdateOpisStanu(2, opisTest3);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(2), null);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(3), opisTest3);

            repo.DeleteOpisStanu(opisTest3);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(3), null);
            Assert.AreEqual<int>(repo.GetAllOpisStanu().Count(), 2);
        }
    }
}
