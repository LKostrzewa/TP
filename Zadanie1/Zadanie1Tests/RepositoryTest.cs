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

            //Katalog katTest3 = new Katalog(50, "Spring w akcji", "Podrecznik", 600);
            katTest2.gatunek = "Podręcznik";
            repo.UpdateKatalog(katTest2);
            //Assert.ThrowsException<KeyNotFoundException>(() => repo.GetKatalog(50));
            Assert.AreEqual(repo.GetKatalog(50), katTest2);

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

            OpisStanu opisTest2 = new OpisStanu(2, katTest, new DateTime(2019, 10, 21));

            repo.AddOpisStanu(opisTest2);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(2), opisTest2);
            Assert.AreEqual<int>(repo.GetAllOpisStanu().Count(), 3);

            //OpisStanu opisTest3 = new OpisStanu(3, katTest, new DateTime(2019, 10, 15));
            opisTest2.dataZakupu = new DateTime(2019, 6, 10);

            repo.UpdateOpisStanu(opisTest2);
            Assert.AreEqual<OpisStanu>(repo.GetOpisStanu(2), opisTest2);
            

            repo.DeleteOpisStanu(opisTest2);
            Assert.ThrowsException<KeyNotFoundException>(() => repo.GetOpisStanu(2));
            Assert.AreEqual<int>(repo.GetAllOpisStanu().Count(), 2);
        }

        [TestMethod]
        public void WykazTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Wykaz wykTest = new Wykaz(2, "Kamil", "Stoch");

            Assert.AreEqual<Wykaz>(repo.GetWykaz(2), wykTest);

            Wykaz wykTest2 = new Wykaz(4, "Simon", "Ammann");

            repo.AddWykaz(wykTest2);
            Assert.AreEqual<Wykaz>(repo.GetWykaz(4), wykTest2);
            Assert.AreEqual<int>(repo.GetAllWykaz().Count(), 4);

            wykTest2.nazwisko = "Morgenstern";

            repo.UpdateWykaz(4, "Simon", "Morgenstern");
            Assert.AreEqual(repo.GetWykaz(4), wykTest2);
            Assert.AreEqual<int>(repo.GetAllWykaz().Count(), 4);

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
            Zdarzenie zdarzTest = new Zdarzenie(wykTest, opisTest);

            Assert.AreEqual<Zdarzenie>(repo.GetZdarzenie(repo.GetWykaz(1), repo.GetOpisStanu(0)), zdarzTest);

            Katalog katTest2 = new Katalog(60, "Pan Tadeusz", "Poemat", 100);
            OpisStanu opisTest2 = new OpisStanu(2, katTest2, new DateTime(2019, 10, 20));
            Zdarzenie zdarzTest2 = new Zdarzenie(wykTest, opisTest2);
            repo.AddZdarzenie(zdarzTest2);
            Assert.AreEqual(repo.GetAllZdarzenie().Count(), 3);

            //Zdarzenie zdarzTest3 = new Zdarzenie(wykTest, opisTest2);
            //repo.UpdateZdarzenie(wykTest, opisTest2, zdarzTest3);
            //Assert.AreEqual(repo.GetZdarzenie(wykTest, opisTest2).czasWypozyczenia.Date, DateTime.Now.AddDays(365).Date);
            //Assert.AreEqual(repo.GetAllZdarzenie().Count(), 3);

            repo.DeleteZdarzenie(zdarzTest2);
            Assert.AreEqual(repo.GetAllZdarzenie().Count(), 2);
            Assert.ThrowsException<InvalidOperationException>(() => repo.GetZdarzenie(wykTest, opisTest2));
        }
    }
}
