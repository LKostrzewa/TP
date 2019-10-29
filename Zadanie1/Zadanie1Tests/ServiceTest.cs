using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void DodawanieKsiazkiTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            ds.DodajKsiazkeDoBiblioteki("Mistrz i Malgorzata", "powiesc", 520);
            Assert.AreEqual<int>(ds.PobierzWszystkieKsiazki().Count(), 5);
            Assert.AreEqual<int>(ds.PobierzWszystkieEgzemplarze().Count(), 5);
            Assert.AreEqual<string>(ds.PobierzEgzemplarz(3).katalog.tytul, "Mistrz i Malgorzata");
            Assert.AreEqual<string>(ds.PobierzKsiazke(0).tytul, "Mistrz i Malgorzata");

            ds.DodajKsiazkeDoBiblioteki("Mistrz i Malgorzata", "powiesc", 520);
            Assert.AreEqual<int>(ds.PobierzWszystkieKsiazki().Count(), 5);
            Assert.AreEqual<int>(ds.PobierzWszystkieEgzemplarze().Count(), 6);
        }

        [TestMethod]
        public void UsuwanieKsiazkiTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            ds.UsunEgzemplarzZBiblioteki(2);
            Assert.AreEqual<int>(ds.PobierzWszystkieEgzemplarze().Count(), 3);
            Assert.ThrowsException<InvalidOperationException>(() => ds.UsunEgzemplarzZBiblioteki(0));
           
            Assert.AreEqual<int>(ds.PobierzWszystkieKsiazki().Count(), 4);
            Assert.ThrowsException<InvalidOperationException>(() => ds.UsunKsiazkeZBiblioteki(10));
            ds.UsunKsiazkeZBiblioteki(30);
            Assert.AreEqual<int>(ds.PobierzWszystkieKsiazki().Count(), 3);
        }

        [TestMethod]
        public void DodawanieKlientaTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            Assert.AreEqual<int>(ds.PobierzWszystkichKlientow().Count(), 3);
            ds.DodajKlientaDoBiblioteki("Andrzej", "Duda");
            Assert.AreEqual<int>(ds.PobierzWszystkichKlientow().Count(), 4);
            Assert.AreEqual<string>(ds.PobierzKlienta(0).imie, "Andrzej");
        }

        [TestMethod]
        public void UsuwanieKlientaTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            Assert.AreEqual<int>(ds.PobierzWszystkichKlientow().Count(), 3);
            Assert.ThrowsException<InvalidOperationException>(() => ds.UsunKlientaZBiblioteki(1));
            ds.UsunKlientaZBiblioteki(2);
            Assert.AreEqual<int>(ds.PobierzWszystkichKlientow().Count(), 2);
        }

        [TestMethod]
        public void WszystkieZdarzeniaDlaKsiazkiTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKsiazki(0).Count(), 1);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKsiazki(2).Count(), 0);
            ds.OddajKsiazke(1, 0);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKsiazki(0).Count(), 2);
            ds.WypozyczKsiazke(2, 2);
            ds.OddajKsiazke(2, 2);
            ds.WypozyczKsiazke(1, 2);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKsiazki(2).Count(), 3);
        }

        [TestMethod]
        public void WszystkieZdarzeniaDlaKlientaTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKlienta(1).Count(), 1);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKlienta(2).Count(), 0);
            ds.OddajKsiazke(1, 0);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKlienta(1).Count(), 2);
            ds.WypozyczKsiazke(2, 0);
            ds.OddajKsiazke(2, 0);
            ds.WypozyczKsiazke(2, 4);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKlienta(2).Count(), 3);
        }

        [TestMethod]
        public void WypozyczKsiazkeTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            Assert.ThrowsException<InvalidOperationException>(() => ds.WypozyczKsiazke(1, 0));
            ds.WypozyczKsiazke(1, 2);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKsiazki(2).Count(), 1);
        }

        [TestMethod]
        public void OddajKsiazkeTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            Assert.ThrowsException<InvalidOperationException>(() => ds.OddajKsiazke(3, 4));
            ds.OddajKsiazke(1, 0);
            Assert.AreEqual<int>(ds.WszystkieZdarzeniaDlaKsiazki(0).Count(), 2);
        }

        [TestMethod]
        public void PokaTest()
        {
            DataService ds = new DataService(new DataRepository(new WypelnianieStalymi()));

            //Console.WriteLine(ds.WyswietlOpisy(ds.PobierzWszystkieEgzemplarze()));
            //Console.WriteLine(ds.WyswietlZdarzenia(ds.PobierzWszystkieZdarzenia()));
        }
    }
}
