using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class LINQ_tools
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (CatalogDataContext dc = new CatalogDataContext())
            {
                Table<Product> productsTable = dc.GetTable<Product>();
                List<Product> products = (from product in productsTable
                                          where product.Name.Contains(namePart)
                                          select product).ToList();

                return products;
            }
        }
    }
}
