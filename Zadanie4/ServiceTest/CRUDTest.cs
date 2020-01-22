using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;

namespace ServiceTest
{
    [TestClass]
    public class CRUDTest
    {
       // private int tmpId;

        [TestMethod]
        public void GetTest()
        {
            ProductService ps = new ProductService();
            MyProduct p = ps.Read(1);

            Assert.AreEqual(p.Name, "Adjustable Race");
            Assert.AreEqual(p.ProductNumber, "AR-5381");
        }


        [TestMethod]
        public void AddTest()
        {
            ProductService ps = new ProductService();


            MyProduct p = new MyProduct();
            p.Name = "test12";
            p.ProductNumber = "4202137";
            p.ModifiedDate = DateTime.Now;
            p.SellStartDate = DateTime.Now.AddDays(-20);
            p.SellEndDate = DateTime.Now.AddDays(20);
            p.SafetyStockLevel = 1;
            p.ReorderPoint = 1;

            ps.Create(p);

            MyProduct p2 = ps.Read(p.ProductID);

            Assert.AreEqual(p.Name, p2.Name);
            Assert.AreEqual(p.ProductNumber, p2.ProductNumber);

            ps.Delete(p.ProductID);

            //tmpId = p.ProductID;
            // Console.WriteLine(tmpId);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ProductService ps = new ProductService();

            MyProduct p = new MyProduct();
            p.Name = "test125";
            p.ProductNumber = "2137420";
            p.ModifiedDate = DateTime.Now;
            p.SellStartDate = DateTime.Now.AddDays(-20);
            p.SellEndDate = DateTime.Now.AddDays(20);
            p.SafetyStockLevel = 1;
            p.ReorderPoint = 1;
            p.rowguid = Guid.NewGuid();

            ps.Create(p);

            Console.WriteLine(p.ProductID);

            MyProduct p2 = new MyProduct();
            p2.ProductID = p.ProductID;
            p2.Name = "test1256";
            p2.ProductNumber = "2137420";
            p2.ModifiedDate = DateTime.Now;
            p2.SellStartDate = DateTime.Now.AddDays(-20);
            p2.SellEndDate = DateTime.Now.AddDays(20);
            p2.SafetyStockLevel = 1;
            p2.ReorderPoint = 1;
            p2.rowguid = Guid.NewGuid();

            ps.Update(p2);

            MyProduct p3 = ps.Read(p.ProductID);

            Assert.AreEqual(p3.Name, p2.Name);
            Assert.AreEqual(p3.Name, "test1256");
            Assert.AreEqual(p3.ProductNumber, p2.ProductNumber);
            ps.Delete(p.ProductID);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ProductService ps = new ProductService();

            MyProduct p = new MyProduct();
            p.Name = "test1257";
            p.ProductNumber = "11111";
            p.ModifiedDate = DateTime.Now;
            p.SellStartDate = DateTime.Now.AddDays(-20);
            p.SellEndDate = DateTime.Now.AddDays(20);
            p.SafetyStockLevel = 1;
            p.ReorderPoint = 1;
            p.rowguid = Guid.NewGuid();

            ps.Create(p);


            MyProduct p2 = ps.Read(p.ProductID);

            Assert.AreEqual(p.Name, p2.Name);
            Assert.AreEqual(p.ProductNumber, p2.ProductNumber);

            ps.Delete(p.ProductID);

            MyProduct p3 = ps.Read(p.ProductID);
            Assert.ThrowsException<NullReferenceException>(() => p3.ProductID);
        }
    }
}
