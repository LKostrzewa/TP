using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;
using Zadanie1;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Zadanie2Test
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void WriteKatalogToFileTest()
        {
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();
            Reading reading = new Reading();

            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            Writing.WriteKatalogToFile(kat, "test.txt", iDGenerator);

            Katalog kat2 = reading.ReadKatalogFromFile("test.txt");

            Console.WriteLine(kat2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteKatalogsToFileTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());

            //tutaj problem o ktorym mowilem ze streamami
           // Writing.WriteKatalogsToFile(dr.GetAllKatalog(), "test1.txt", new ObjectIDGenerator());
        }

        [TestMethod]
        public void WriteKatalogToJSONTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            Writing.WriteObjectToJSON(kat, "test1.json");

            Katalog kat2 = Reading.ReadObjectFromJSON<Katalog>("test1.json");

            Console.WriteLine(kat2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteWykazToFileTest()
        {
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();
            Reading reading = new Reading();

            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Writing.WriteWykazToFile(wykaz, "test3.txt", iDGenerator);

            Wykaz wyk2 = reading.ReadWykazFromFile("test3.txt");

            Console.WriteLine(wyk2);
            Assert.AreEqual<Wykaz>(wykaz, wyk2);
        }

        [TestMethod]
        public void WriteWykazToJSONTest()
        {
            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Writing.WriteObjectToJSON(wykaz, "test4.json");

            Wykaz wyk2 = Reading.ReadObjectFromJSON<Wykaz>("test4.json");

            Console.WriteLine(wyk2);
            Assert.AreEqual<Wykaz>(wykaz, wyk2);
        }

        [TestMethod]
        public void WriteOpisStanuToJSONTest()
        {
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Writing.WriteObjectToJSON(opis, "test5.json");

            OpisStanu opis2 = Reading.ReadObjectFromJSON<OpisStanu>("test5.json");
            Katalog kat2 = opis2.katalog;

            Console.WriteLine(opis2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteOpisStanuToFileTest()
        {
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();

            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Writing.WriteKatalogToFile(kat, "pliczek.txt", iDGenerator);
            Writing.WriteOpisStanuToFile(opis, "test6.txt", iDGenerator);

            Dictionary<string, Katalog> helperKatalog = new Dictionary<string, Katalog>();
            Reading reading = new Reading();
            Katalog kat2 = reading.ReadKatalogFromFile("pliczek.txt");
            OpisStanu opis2 = reading.ReadOpisStanuFromFile("test6.txt");

            //Console.WriteLine(opis2);
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
            Writing.WriteObjectToJSON(wyp, "test7.json");

            Wypozyczenie wyp2 = Reading.ReadObjectFromJSON<Wypozyczenie>("test7.json");
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
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();
            Katalog kat = new Katalog(0, "Programowanie c#", "Podrecznik", 520);
            OpisStanu opis = new OpisStanu(1, kat, DateTime.Now);
            Wykaz wykaz = new Wykaz(0, "Adam", "Małysz");
            Wypozyczenie wyp = new Wypozyczenie(0, wykaz, opis);
            Writing.WriteKatalogToFile(kat, "kat1.txt", iDGenerator);
            Writing.WriteOpisStanuToFile(opis, "opis1.txt", iDGenerator);
            Writing.WriteWykazToFile(wykaz, "wykaz1.txt", iDGenerator);
            Writing.WriteZdarzenieToFile(wyp, "wyp1.txt", iDGenerator);

            Reading reading = new Reading();
            Katalog kat2 = reading.ReadKatalogFromFile("kat1.txt");
            OpisStanu opis2 = reading.ReadOpisStanuFromFile("opis1.txt");
            Wykaz wykaz2 = reading.ReadWykazFromFile("wykaz1.txt");
            Wypozyczenie wyp2 = (Wypozyczenie)reading.ReadZdarzenieFromFile("wyp1.txt", true);

            //Console.WriteLine(wyp2);
            Assert.AreEqual<Zdarzenie>(wyp, wyp2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
            Assert.AreEqual<Wykaz>(wykaz, wykaz2);
        }

        [TestMethod]
        public void WriteCollectionToJSONTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());

            Writing.WriteCollectionToJSON<Katalog>(dr.GetAllKatalog(), "test9.json");
            Writing.WriteCollectionToJSON<OpisStanu>(dr.GetAllOpisStanu(), "test10.json");

            Katalog[] proper = dr.GetAllKatalog().ToArray();
            List<Katalog> test = (List<Katalog>)Reading.ReadCollectionFromJSON<Katalog>("test9.json");
            for(int i = 0; i < test.Count; i++)
            {
                Assert.AreEqual<Katalog>(proper[i], test[i]);
                //Console.WriteLine(test[i]);
            }
        }

        /*[TestMethod]
        public void OwnSerializationJSONTest()
        {
            IFormatter jf = new JsonFormatter();


            Katalog kat = new Katalog(0, "Solaris", "sci-fi", 420);
            jf.Serialize(new FileStream("test10.json", FileMode.Create), kat);
            OpisStanu opis = new OpisStanu(0, kat, DateTime.Now);
            jf.Serialize(new FileStream("test11.json", FileMode.Create), opis);

            object ob =  jf.Deserialize(new FileStream("test10.json", FileMode.Open));
            //OpisStanu os = (OpisStanu) jf.Deserialize(new FileStream("test11.json", FileMode.Open));
            //OpisStanu lol = (OpisStanu)os;
        }*/

        [TestMethod]
        public void ObjectToJSONTest()
        {
            Writing.WriteObjectToJSON(new OpisStanu(0, 
                new Katalog(0, "Programowanie c#", "Podrecznik", 520), DateTime.Now), "test11.json");

            OpisStanu os = Reading.ReadObjectFromJSON<OpisStanu>("test11.json");
        }

        [TestMethod]
        public void CustomFormatterTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());

            FileStream ms = new FileStream("Elko_v2.csv", FileMode.Create);
            var serializer = new CustomFormatter<OpisStanu>(';', true);
            serializer.Serialize(ms, dr.GetAllOpisStanu());
            ms.Close();

            FileStream fs = new FileStream("Test69.csv", FileMode.Create);
            var serializer2 = new CustomFormatter<Wykaz>(';', true);
            serializer2.Serialize(fs, dr.GetAllWykaz());
            fs.Close();

            FileStream fs2 = new FileStream("Elko_v2.csv", FileMode.Open);
            var serialzier3 = new CustomFormatter<Wykaz>(';', true);
            List<Wykaz> result = (List<Wykaz>)serialzier3.Deserialize(fs2);


            foreach(var el in result){
                Console.WriteLine(el);
            }
            

            //Nie dziala:
           /* var serializer2 = new CustomFormatter<OpisStanu>(';', true);
            List<OpisStanu> result;
            FileStream fs = new FileStream("Elko_v2.csv", FileMode.Open);
            result = (List<OpisStanu>)serializer2.Deserialize(fs);*/
        }
    }
}
