using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace GUI.ViewModel
{
    class MaintenanceFormViewModel : INotifyPropertyChanged
    {
        ProductService productService = new ProductService();

        public MaintenanceFormViewModel(ProductService productService)
        {
            this.productService = productService;
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
