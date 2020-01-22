using ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DI
{
    public class ProductDetailsResolver : IWindowResolver
    {
        public IOperationWindow GetWindow()
        {
            return new ProductDetailsWindow();
        }
    }
}
