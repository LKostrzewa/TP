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
        public event VoidHandler CollectionChanged;
        public delegate void VoidHandler();

        public void Create(Product product)
        {
            //Task.Run(() =>
            //{
                LINQ_tools.InsertNewProduct(product);
               // CollectionChanged?.Invoke();
           // });
        }

        public Product Read(int id)
        {
            return LINQ_tools.GetProductById(id);
        }

        public void Update(Product product)
        {
           // Task.Run(() =>
           // {
                LINQ_tools.UpdateProduct(product);
               // CollectionChanged?.Invoke();
           // });
        }

        public void Delete(int id)
        {
            //Task.Run(() =>
            //{
                LINQ_tools.DeleteProductId(id);
               // CollectionChanged?.Invoke();
           // });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return LINQ_tools.GetAllProducts();
        }

    }
}
