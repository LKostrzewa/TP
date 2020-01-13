using GUI.Common;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel
{
    class ProductListViewModel
    {
        private static ProductListViewModel instance = null;

        //the selected customer (for showing orders for that customer)
        private ProductViewModel selectedProduct = null;

        //the complete customer list
        private ObservableCollection<ProductViewModel> productList = null;

        //for opening up the Add Customer window
        private ICommand showAddCommand;

        public static ProductListViewModel Instance()
        {
            if (instance == null)
                instance = new ProductListViewModel();
            return instance;
        }

        public ObservableCollection<ProductViewModel> ProductList
        {
            get
            {
                return GetProducts();
            }
            set
            {
                productList = value;
                OnPropertyChanged("ProductList");
            }
        }

        public ProductViewModel SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ICommand ShowAddCommand
        {
            get
            {
                if (showAddCommand == null)
                {
                    showAddCommand = new CommandBase(i => this.ShowAddDialog(), null);
                }
                return showAddCommand;
            }
        }

        private ProductListViewModel()
        {
            this.ProductList = GetProducts();
        }

        //czym tu jest internal tylko Bozia wie
        internal ObservableCollection<ProductViewModel> GetProducts()
        {
            if (productList == null)
                productList = new ObservableCollection<ProductViewModel>();
            productList.Clear();
            foreach (Product p in new ProductService().GetAllProducts())
            {
                ProductViewModel c = new ProductViewModel(p);
                productList.Add(c);
            }
            return productList;
        }

        private void ShowAddDialog()
        {
            //nie mam pojecia
            
            ProductViewModel product = new ProductViewModel();
            product.Mode = Mode.Add;

            IModalDialog dialog = product.ModalDialog;
            dialog.BindViewModel(product);
            dialog.ShowDialog();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
