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
    }
}
