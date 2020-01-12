using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;
using System.Windows.Input;
using GUI.Common;

namespace GUI.ViewModel
{
    class ProductViewModel 
    {
        private ProductService productService = new ProductService();

        private string productName;
        private string productNumber;

        //for opening up the Edit Customer window
        private ICommand showEditCommand;

        //for adding/saving customer information
        private ICommand updateCommand;

        //for deleting a customer
        private ICommand deleteCommand;

        //for cancel an Edit
        private ICommand cancelCommand;

        private ProductViewModel originalValue;

        public int ProductId
        {
            get;
            set;
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public string ProductNumber
        {
            get { return productNumber; }
            set
            {
                productNumber = value;
                OnPropertyChanged("ProductNumber");
            }
        }

        public Mode Mode
        {
            get;
            set;
        }

        public ProductListViewModel Container
        {
            get { return ProductListViewModel.Instance(); }
        }

        private void ShowEditDialog()
        {
            this.Mode = ViewModel.Mode.Edit;
            //nwm co tu :(
            /*IModalDialog dialog = ServiceProvider.Instance.Get<IModalDialog>();
            dialog.BindViewModel(this); //bind to this viewModel
            dialog.ShowDialog();*/
        }

        public ICommand ShowEditCommand
        {
            get
            {
                if (showEditCommand == null)
                {
                    showEditCommand = new CommandBase(i => this.ShowEditDialog(), null);
                }
                return showEditCommand;
            }
        }

        private IEnumerable<Product> products;
        public IEnumerable<Product> Products
        {
            get
            {
                return this.Products;
            }
            set
            {
                this.products = value;
                this.OnPropertyChanged("Product");
            }
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
