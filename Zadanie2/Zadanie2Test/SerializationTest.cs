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
    }
}
