using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class ProductService : IProductService
    {

        public void Create(MyProduct product)
        {
            Product p = new Product();
            p.ProductID = product.ProductID;
            p.ProductNumber = product.ProductNumber;
            p.Name = product.Name;
            p.ModifiedDate = product.ModifiedDate;
            p.SellStartDate = product.SellStartDate;
            p.SellEndDate = product.SellEndDate;
            p.SafetyStockLevel = product.SafetyStockLevel;
            p.ReorderPoint = product.ReorderPoint;
            p.Color = product.Color;
            p.rowguid = product.rowguid;
            LINQ_tools.InsertNewProduct(p);
            product.ProductID = p.ProductID;
        }

        public MyProduct Read(int id)
        {
            Product p = LINQ_tools.GetProductById(id);
            return new MyProduct(p);
        }

        public void Update(MyProduct product)
        {
            Product p = new Product();
            p.ProductID = product.ProductID;
            p.ProductNumber = product.ProductNumber;
            p.Name = product.Name;
            p.ModifiedDate = product.ModifiedDate;
            p.SellStartDate = product.SellStartDate;
            p.SellEndDate = product.SellEndDate;
            p.SafetyStockLevel = product.SafetyStockLevel;
            p.ReorderPoint = product.ReorderPoint;
            p.Color = product.Color;
            p.rowguid = product.rowguid;
            LINQ_tools.UpdateProduct(p);
            product.ProductID = p.ProductID;
        }

        public void Delete(int id)
        {
            LINQ_tools.DeleteProductId(id);
        }

        public IEnumerable<MyProduct> GetAllProducts()
        {
            List<MyProduct> myProducts = new List<MyProduct>();
            foreach(Product p in LINQ_tools.GetAllProducts())
            {
                myProducts.Add(new MyProduct(p));
            }
            return myProducts;
            //return (IEnumerable<MyProduct>)LINQ_tools.GetAllProducts();
        }

    }
}
