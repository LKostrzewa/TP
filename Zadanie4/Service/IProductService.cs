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

        void Create(MyProduct product);

        MyProduct Read(int id);

        void Update(MyProduct product);

        void Delete(int id);

        IEnumerable<MyProduct> GetAllProducts();
    }
}
