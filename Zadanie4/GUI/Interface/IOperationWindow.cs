using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interface
{
    public interface IOperationWindow
    {
        void BindViewModel<T>(T viewModel) where T : IViewModel;
        void Show();
        event VoidHandler OnClose;
    }

    public delegate void VoidHandler();
}
