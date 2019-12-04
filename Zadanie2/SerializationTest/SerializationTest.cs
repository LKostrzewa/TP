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
            Class1 class1 = new Class1(2.5f, DateTime.Now, "klasa 1");
            Class2 class2 = new Class2(7.5f, DateTime.Now.AddDays(5), "klasa 2");
            Class3 class3 = new Class3(12.2f, DateTime.Now.AddMonths(2), "klasa 3");
            class1.obj = class2;
            class2.obj = class3;
            class3.obj = class1;

            JsonFormatter jsonFormatter = new JsonFormatter();
            jsonFormatter.Serialize(new FileStream("plik1.json", FileMode.Create), class1);
            Class1 class1prim = jsonFormatter.Deserialize<Class1>(new FileStream("plik1.json", FileMode.Open));
            Assert.AreEqual(class1.num, class1prim.num);
            Assert.AreEqual(class1.date, class1prim.date);
            Assert.AreEqual(class1.name, class1prim.name);
            Assert.AreEqual(class1.obj.num, class1prim.obj.num);
            Assert.AreEqual(class1.obj.date, class1prim.obj.date);
            Assert.AreEqual(class1.obj.name, class1prim.obj.name);
            Assert.AreEqual(class1.obj.obj.num, class1prim.obj.obj.num);
            Assert.AreEqual(class1.obj.obj.date, class1prim.obj.obj.date);
            Assert.AreEqual(class1.obj.obj.name, class1prim.obj.obj.name);
        }

        [TestMethod]
        public void CustomFormatterTest()
        {
            Class1 class1 = new Class1(2.5f, DateTime.Now, "klasa 1");
            Class2 class2 = new Class2(7.5f, DateTime.Now.AddDays(5), "klasa 2");
            Class3 class3 = new Class3(12.2f, DateTime.Now.AddMonths(2), "klasa 3");
            class1.obj = class2;
            class2.obj = class3;
            class3.obj = class1;

            CustomFormatter cs = new CustomFormatter();
            FileStream a = new FileStream("plik1.txt", FileMode.Create);
            cs.Serialize(a, class1);
            a.Flush();
            a.Close();
            Class1 class1prim = cs.Deserialize(new FileStream("plik1.txt", FileMode.Open)) as Class1;

            Assert.AreEqual(class1.num, class1prim.num);
            Assert.AreEqual(class1.date.Date, class1prim.date.Date);
            Assert.AreEqual(class1.date.Hour, class1prim.date.Hour);
            Assert.AreEqual(class1.date.Minute, class1prim.date.Minute);
            Assert.AreEqual(class1.date.Second, class1prim.date.Second);
            Assert.AreEqual(class1.name, class1prim.name);
            Assert.AreEqual(class1.obj.num, class1prim.obj.num);
            Assert.AreEqual(class1.obj.date.Date, class1prim.obj.date.Date);
            Assert.AreEqual(class1.obj.date.Hour, class1prim.obj.date.Hour);
            Assert.AreEqual(class1.obj.date.Minute, class1prim.obj.date.Minute);
            Assert.AreEqual(class1.obj.date.Second, class1prim.obj.date.Second);
            Assert.AreEqual(class1.obj.name, class1prim.obj.name);
            Assert.AreEqual(class1.obj.obj.num, class1prim.obj.obj.num);
            Assert.AreEqual(class1.obj.obj.date.Date, class1prim.obj.obj.date.Date);
            Assert.AreEqual(class1.obj.obj.date.Hour, class1prim.obj.obj.date.Hour);
            Assert.AreEqual(class1.obj.obj.date.Minute, class1prim.obj.obj.date.Minute);
            Assert.AreEqual(class1.obj.obj.date.Second, class1prim.obj.obj.date.Second);
            Assert.AreEqual(class1.obj.obj.name, class1prim.obj.obj.name);
        }
    }
}
