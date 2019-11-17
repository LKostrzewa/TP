using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;
using Zadanie1;

namespace Zadanie2Test
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void WriteKatalogToFileTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            Writing.WriteKatalogToFile(kat, "test.txt");

            Katalog kat2 = Reading.ReadKatalogFromFile("test.txt");

            Console.WriteLine(kat2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteKatalogToJSONTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            Writing.WriteKatalogToJSON(kat, "test2.json");

            Katalog kat2 = Reading.ReadKatalogFromJSON("test2.json");

            Console.WriteLine(kat2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteWykazToFileTest()
        {
            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Writing.WriteWykazToFile(wykaz, "test3.txt");

            Wykaz wyk2 = Reading.ReadWykazFromFile("test3.txt");

            Console.WriteLine(wyk2);
            Assert.AreEqual<Wykaz>(wykaz, wyk2);
        }

        [TestMethod]
        public void WriteWykazToJSONTest()
        {
            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Writing.WriteWykazToJSON(wykaz, "test4.json");

            Wykaz wyk2 = Reading.ReadWykazFromJSON("test4.json");

            Console.WriteLine(wyk2);
            Assert.AreEqual<Wykaz>(wykaz, wyk2);
        }

        [TestMethod]
        public void WriteOpisStanuToJSONTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Writing.WriteOpisStanuToJSON(opis, "test5.json");

            OpisStanu opis2 = Reading.ReadOpisStanuFromJSON("test5.json");
            Katalog kat2 = opis2.katalog;

            Console.WriteLine(opis2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteOpisStanuToFileTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Writing.WriteOpisStanuToFile(opis, "test8.json");

            OpisStanu opis2 = Reading.ReadOpisStanuFromFile("test8.json");
            Katalog kat2 = opis2.katalog;

            Console.WriteLine(opis2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteZdarzenieToJSONTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Wypozyczenie wyp = new Wypozyczenie(0, wykaz, opis);
            Writing.WriteZdarzenieToJSON(wyp, "test6.json");

            Wypozyczenie wyp2 = (Wypozyczenie)Reading.ReadZdarzenieFromJSON("test6.json", true);
            OpisStanu opis2 = wyp2.opis;
            Wykaz wykaz2 = wyp2.wykaz;
            Katalog kat2 = opis2.katalog;

            Console.WriteLine(wyp2);
            Assert.AreEqual<Zdarzenie>(wyp, wyp2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
            Assert.AreEqual<Wykaz>(wykaz, wykaz2);
        }

        [TestMethod]
        public void WriteZdarzenieToFileTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Wypozyczenie wyp = new Wypozyczenie(0, wykaz, opis);
            Writing.WriteZdarzenieToFile(wyp, "test7.json");

            Wypozyczenie wyp2 = (Wypozyczenie)Reading.ReadZdarzenieFromFile("test7.json", true);
            OpisStanu opis2 = wyp2.opis;
            Wykaz wykaz2 = wyp2.wykaz;
            Katalog kat2 = opis2.katalog;

            Console.WriteLine(wyp2);
            Assert.AreEqual<Zdarzenie>(wyp, wyp2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
            Assert.AreEqual<Wykaz>(wykaz, wykaz2);
        }
    }
}
