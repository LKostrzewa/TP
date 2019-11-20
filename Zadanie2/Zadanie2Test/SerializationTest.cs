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
            Writing.WriteKatalogToFile(kat, "test.txt", iDGenerator, false);

            Katalog kat2 = reading.ReadKatalogFromFile("test.txt");

            Console.WriteLine(kat2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteKatalogsToFileTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Reading read = new Reading();
            
            Writing.WriteKatalogsToFile(dr.GetAllKatalog(), "test111.txt", new ObjectIDGenerator());
            Katalog[] proper = dr.GetAllKatalog().ToArray();
            List<Katalog> test = (List<Katalog>)read.ReadKatalogsFromFile("test111.txt");
            for (int i = 0; i < test.Count; i++)
            {
                Assert.AreEqual<Katalog>(proper[i], test[i]);
                //Console.WriteLine(test[i]);
            }
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
            Writing.WriteWykazToFile(wykaz, "test3.txt", iDGenerator, false);

            Wykaz wyk2 = reading.ReadWykazFromFile("test3.txt");

            Console.WriteLine(wyk2);
            Assert.AreEqual<Wykaz>(wykaz, wyk2);
        }

        [TestMethod]
        public void WriteWykazsToFileTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Reading read = new Reading();

            Writing.WriteWykazsToFile(dr.GetAllWykaz(), "test112.txt", new ObjectIDGenerator());
            Wykaz[] proper = dr.GetAllWykaz().ToArray();
            List<Wykaz> test = (List<Wykaz>)read.ReadWykazsFromFile("test112.txt");
            for (int i = 0; i < test.Count; i++)
            {
                Assert.AreEqual<Wykaz>(proper[i], test[i]);
                //Console.WriteLine(test[i]);
            }
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
            Writing.WriteKatalogToFile(kat, "pliczek.txt", iDGenerator, false);
            Writing.WriteOpisStanuToFile(opis, "test6.txt", iDGenerator, false);

            Reading reading = new Reading();
            Katalog kat2 = reading.ReadKatalogFromFile("pliczek.txt");
            OpisStanu opis2 = reading.ReadOpisStanuFromFile("test6.txt");

            //Console.WriteLine(opis2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
        }

        [TestMethod]
        public void WriteOpisStanusToFileTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Reading read = new Reading();
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();

            Writing.WriteKatalogsToFile(dr.GetAllKatalog(), "test111.txt", iDGenerator);
            Writing.WriteOpisStanusToFile(dr.GetAllOpisStanu(), "test113.txt", iDGenerator);

            Katalog[] proper = dr.GetAllKatalog().ToArray();
            OpisStanu[] proper2 = dr.GetAllOpisStanu().ToArray();
            List<Katalog> test = (List<Katalog>)read.ReadKatalogsFromFile("test111.txt");
            List<OpisStanu> test2 = (List<OpisStanu>)read.ReadOpisStanusFromFile("test113.txt");
            for (int i = 0; i < test.Count; i++)
            {
                Assert.AreEqual<OpisStanu>(proper2[i], test2[i]);
                //Console.WriteLine(test[i]);
            }
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
            Writing.WriteKatalogToFile(kat, "kat1.txt", iDGenerator, false);
            Writing.WriteOpisStanuToFile(opis, "opis1.txt", iDGenerator,false);
            Writing.WriteWykazToFile(wykaz, "wykaz1.txt", iDGenerator, false);
            Writing.WriteZdarzenieToFile(wyp, "wyp1.txt", iDGenerator, false);

            Reading reading = new Reading();
            Katalog kat2 = reading.ReadKatalogFromFile("kat1.txt");
            OpisStanu opis2 = reading.ReadOpisStanuFromFile("opis1.txt");
            Wykaz wykaz2 = reading.ReadWykazFromFile("wykaz1.txt");
            Zdarzenie wyp2 = reading.ReadZdarzenieFromFile("wyp1.txt");

            //Console.WriteLine(wyp2);
            Assert.AreEqual<Zdarzenie>(wyp, wyp2);
            Assert.AreEqual<OpisStanu>(opis, opis2);
            Assert.AreEqual<Katalog>(kat, kat2);
            Assert.AreEqual<Wykaz>(wykaz, wykaz2);
        }

        [TestMethod]
        public void WriteZdarzeniesToFileTest()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Reading reading = new Reading();
            ObjectIDGenerator iDGenerator = new ObjectIDGenerator();


            Writing.WriteKatalogsToFile(dr.GetAllKatalog(), "listkat1.txt", iDGenerator);
            Writing.WriteOpisStanusToFile(dr.GetAllOpisStanu(), "listopis1.txt", iDGenerator);
            Writing.WriteWykazsToFile(dr.GetAllWykaz(), "listwykaz1.txt", iDGenerator);
            Writing.WriteZdarzeniesToFile(dr.GetAllZdarzenie(), "listzdarz1.txt", iDGenerator);

            Katalog[] katalogsOrginal = dr.GetAllKatalog().ToArray();
            OpisStanu[] opisStanusOriginal = dr.GetAllOpisStanu().ToArray();
            Wykaz[] wykazsOriginal = dr.GetAllWykaz().ToArray();
            Zdarzenie[] zdarzeniesOriginal = dr.GetAllZdarzenie().ToArray();

            List<Katalog> katalogs = (List<Katalog>)reading.ReadKatalogsFromFile("listkat1.txt");
            List<OpisStanu> opisStanus = (List<OpisStanu>)reading.ReadOpisStanusFromFile("listopis1.txt");
            List<Wykaz> wykazs = (List<Wykaz>)reading.ReadWykazsFromFile("listwykaz1.txt");
            List<Zdarzenie> zdarzenies = (List<Zdarzenie>)reading.ReadZdarzeniesFromFile("listzdarz1.txt");


            for (int i = 0; i < katalogs.Count; i++)
            {
                Assert.AreEqual<Katalog>(katalogs[i], katalogsOrginal[i]);
            }

            for (int i = 0; i < zdarzenies.Count; i++)
            {
                Assert.AreEqual<Zdarzenie>(zdarzenies[i], zdarzeniesOriginal[i]);
                //Console.WriteLine(zdarzenies[i].GetType() + " - " + zdarzeniesOriginal[i].GetType());
            }
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

        /*[TestMethod]
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
        }*/
    }
}
