using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Zadanie1Tests
{
    [TestClass]
    public class CrudTests
    {

        [TestMethod]
        public void KatalogTest()
        {
            DataRepository repo = new DataRepository(new WypelnianieStalymi());

            Katalog katTest = new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100);
            Assert.AreEqual<Katalog>(repo.GetKatalog(10), katTest);

            repo.DeleteKatalog(katTest);

        }
    }
}
