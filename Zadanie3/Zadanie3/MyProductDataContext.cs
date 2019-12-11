using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductDataContext : IDisposable
    {
        public List<MyProduct> myProducts { get; set; }

        public MyProductDataContext(CatalogDataContext catalogDataContext)
        {
            myProducts = catalogDataContext.GetTable<Product>().Select(p => new MyProduct(p)).ToList();
        }

        public void Dispose()
        {
            myProducts.Clear();
        }
    }
}
