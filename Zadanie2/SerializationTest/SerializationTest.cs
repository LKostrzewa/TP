using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;

namespace Zadanie2Test
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void JsonFormatterTest()
        {
            /*Class1 class1 = new Class1();
            JsonFormatter jsonFormatter = new JsonFormatter();
            jsonFormatter.Serialize(new FileStream("plik1.json", FileMode.Create) ,class1);
            Class1 class12 = new Class1();
            jsonFormatter.Deserialize(new FileStream("plik1.json", FileMode.Open));

            Assert.AreEqual<Class1>(class1, class12);*/

        }

        [TestMethod]
        public void CustomFormatterTest()
        {

        }
    }
}
