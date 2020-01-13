using GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Interface;

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
