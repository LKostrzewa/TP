using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;

namespace ServiceTest
{
    [TestClass]
    public class CRUDTest
    {
        private int tmpId;

        [TestMethod]
        public void GetTest()
        {
            ProductService ps = new ProductService();
            Product p = ps.Read(1);

            Assert.AreEqual(p.Name, "Adjustable Race");
            Assert.AreEqual(p.ProductNumber, "AR-5381");
        }


        [TestMethod]
        public void AddTest()
        {
            ProductService ps = new ProductService();


            Product p = new Product();
            p.Name = "test12";
            p.ProductNumber = "4202137";
            p.ModifiedDate = DateTime.Now;
            p.SellStartDate = DateTime.Now.AddDays(-20);
            p.SellEndDate = DateTime.Now.AddDays(20);
            p.SafetyStockLevel = 1;
            p.ReorderPoint = 1;

            ps.Create(p);

            Product p2 = ps.Read(p.ProductID);

            Assert.AreEqual(p.Name, p2.Name);
            Assert.AreEqual(p.ProductNumber, p2.ProductNumber);

            tmpId = p.ProductID;
            Console.WriteLine(tmpId);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ProductService ps = new ProductService();

            Product p = new Product();
            p.ProductID = tmpId;
            p.Name = "test125";
            p.ProductNumber = "2137420";
            p.ModifiedDate = DateTime.Now;
            p.SellStartDate = DateTime.Now.AddDays(-20);
            p.SellEndDate = DateTime.Now.AddDays(20);
            p.SafetyStockLevel = 1;
            p.ReorderPoint = 1;

            ps.Update(p);

            Product p2 = ps.Read(tmpId);

            Assert.AreEqual(p.Name, p2.Name);
            Assert.AreEqual(p.ProductNumber, p2.ProductNumber);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ProductService ps = new ProductService();

            ps.Delete(tmpId);
        }
    }
}
