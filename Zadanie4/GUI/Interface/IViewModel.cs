using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interface
{
    public interface IViewModel
    {
        Action CloseWindow { get; set; }
    }
}
