﻿using GUI.Common;
using GUI.Interface;
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
        private ProductService productService = null;
        public List<Product> products;

        //the selected customer (for showing orders for that customer)
        private ProductViewModel selectedProduct = null;

        //the complete customer list
        private ObservableCollection<ProductViewModel> productList = null;

        //for opening up the Add Customer window
        private ICommand showAddCommand;
        private ICommand showEditCommand;

        public IWindowResolver WindowResolver { get; set; }

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
                //OnPropertyChanged("ProductList");
            }
        }

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
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
                //selectedProduct.
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

        public ProductListViewModel() : this(new ProductService())
        {
            //this.ProductList = GetProducts();
            //this.openDialogCommand = new RelayCommand(OnOpenDialog);
        }

        public ProductListViewModel(ProductService productService)
        {
            this.productService = productService;
            this.Products = (List<Product>)productService.GetAllProducts();
            productService.CollectionChanged += OnProductsChanged;
        }

        private void OnProductsChanged()
        {
            this.Products = (List<Product>)productService.GetAllProducts();
        }

        internal ObservableCollection<ProductViewModel> GetProducts()
        {
            if (productList == null)
                productList = new ObservableCollection<ProductViewModel>();
            productList.Clear();
            foreach (Product p in Products)
            {
                ProductViewModel c = new ProductViewModel(p, productService);
                productList.Add(c);
            }
            return productList;
        }
        
        private void ShowAddDialog()
        {
            ProductViewModel product = new ProductViewModel();
            product.Mode = Mode.Add;

            IOperationWindow dialog = WindowResolver.GetWindow();
            dialog.BindViewModel(product);
            dialog.Show();
            product.Container.ProductList = GetProducts();
        }

        private void ShowEditDialog()
        {
            //ProductViewModel product = new ProductViewModel(SelectedProduct);
            SelectedProduct.Mode = Mode.Edit;

            IOperationWindow dialog = WindowResolver.GetWindow();
            dialog.BindViewModel(SelectedProduct);
            dialog.Show();
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
