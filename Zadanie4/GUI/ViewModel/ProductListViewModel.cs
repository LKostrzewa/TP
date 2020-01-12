using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    class ProductListViewModel
    {
        private static ProductListViewModel instance = null;

        public static ProductListViewModel Instance()
        {
            if (instance == null)
                instance = new ProductListViewModel();
            return instance;
        }
    }
}
