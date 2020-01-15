using GUI.Interface;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DI
{
    class ProductDetailsWindow : IOperationWindow
    {
        private ProductView _view;
        public event VoidHandler OnClose;

        public ProductDetailsWindow()
        {
            _view = new ProductView();
        }

        public void BindViewModel<T>(T viewModel) where T : IViewModel
        {
            _view.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                OnClose?.Invoke();
                _view.Close();
            };
        }

        public void Show()
        {
            _view.Show();
        }
    }
}
