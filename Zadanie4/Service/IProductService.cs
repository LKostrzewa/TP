using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {

        void Create(Product product);

        Product Read(int id);

        void Update(Product product);

        void Delete(int id);

        IEnumerable<Product> GetAllProducts();
    }
}
