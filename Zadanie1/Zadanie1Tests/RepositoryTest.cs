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
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetKatalog(60));

            Katalog katTest2 = new Katalog(50, "Jezyk C#", "Podrecznik", 500);

            repo.AddKatalog(katTest2);
            Assert.AreEqual<Katalog>(repo.GetKatalog(50), katTest2);
            Assert.AreEqual<int>(repo.GetAllKatalog().Count(), 5);

            repo.UpdateKatalog(50, "Spring w akcji", "Ksiazka specjalistyczna");
            Assert.AreEqual<string>(repo.GetKatalog(50).tytul, "Spring w akcji");
            Assert.ThrowsException<KeyNotFoundException>(() => repo.UpdateKatalog(60, "nie ma", "katalogu"));

            repo.DeleteKatalog(50);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetKatalog(50));
            Assert.AreEqual<int>(repo.GetAllKatalog().Count(), 4);
        }

        [TestMethod]
        public void OpisStanuTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Katalog katTest = new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100);
            OpisStanu opisTest = new OpisStanu(0, katTest, new DateTime(2019, 10, 5));

            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(0), opisTest);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetOpisStanu(21));

            OpisStanu opisTest2 = new OpisStanu(3, katTest, new DateTime(2019, 10, 21));

            repo.AddOpisStanu(opisTest2);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(3), opisTest2);
            Assert.AreEqual<int>(repo.GetAllOpisStanu().Count(), 5);
            
            repo.DeleteOpisStanu(opisTest2);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetOpisStanu(3));
            Assert.AreEqual<int>(repo.GetAllOpisStanu().Count(), 4);
        }

        [TestMethod]
        public void WykazTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Wykaz wykTest = new Wykaz(2, "Kamil", "Stoch");

            Assert.AreEqual<Wykaz>(repo.GetWykaz(2), wykTest);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetWykaz(7));

            Wykaz wykTest2 = new Wykaz(4, "Simon", "Ammann");

            repo.AddWykaz(wykTest2);
            Assert.AreEqual<Wykaz>(repo.GetWykaz(4), wykTest2);
            Assert.AreEqual<int>(repo.GetAllWykaz().Count(), 4);

            repo.UpdateWykaz(4, "Simon", "Morgenstern");
            Assert.AreEqual<string>(repo.GetWykaz(4).nazwisko, "Morgenstern");
            Assert.ThrowsException<KeyNotFoundException>(() => repo.UpdateWykaz(7, "nie ma", "wykazu"));

            repo.DeleteWykaz(wykTest2);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetWykaz(4));
            Assert.AreEqual<int>(repo.GetAllWykaz().Count(), 3);
        }

        [TestMethod]
        public void ZdarzenieTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Wykaz wykTest = new Wykaz(1, "Adam", "Małysz");
            Katalog katTest = new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100);
            OpisStanu opisTest = new OpisStanu(0, katTest, new DateTime(2019, 10, 5));
            Zdarzenie zdarzTest = new Zdarzenie(0, wykTest, opisTest);

            Assert.AreEqual<Zdarzenie>(repo.GetZdarzenie(0), zdarzTest);

            Katalog katTest2 = new Katalog(60, "Pan Tadeusz", "Poemat", 100);
            OpisStanu opisTest2 = new OpisStanu(2, katTest2, new DateTime(2019, 10, 20));
            Zdarzenie zdarzTest2 = new Zdarzenie(2, wykTest, opisTest2);
            repo.AddZdarzenie(zdarzTest2);
            Assert.AreEqual<Zdarzenie>(zdarzTest2, repo.GetZdarzenie(2));
            Assert.AreEqual(repo.GetAllZdarzenie().Count(), 3);

            repo.DeleteZdarzenie(zdarzTest2);
            Assert.AreEqual(repo.GetAllZdarzenie().Count(), 2);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetZdarzenie(2));
        }
    }
}
