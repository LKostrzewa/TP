﻿using System;
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
    class ProductViewModel : INotifyPropertyChanged
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

        public ProductViewModel(Product c)
        {
            ProductId = c.ProductID;
            productName = c.Name;
            productNumber = c.ProductNumber;
            //copy the current value so in case cancel you can undo
            this.originalValue = (ProductViewModel)this.MemberwiseClone();
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

        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new CommandBase(i => this.Update(), null);
                }
                return updateCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new CommandBase(i => this.Delete(), null);
                }
                return deleteCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new CommandBase(i => this.Undo(), null);
                }
                return cancelCommand;
            }
        }

        private void Update()
        {
            if(this.Mode == Mode.Add)
            {
                Product product = new Product();
                product.ProductNumber = this.ProductNumber;
                product.Name = this.ProductName;
                productService.Create(product);
                //refreshTheView
                //this.Container = this.Container.GetCustomers();
            }
            else if(this.Mode == Mode.Edit)
            {
                Product product = new Product();
                product.ProductNumber = this.ProductNumber;
                product.Name = this.ProductName;
                productService.Update(product);
                //copy the current value so in case cancel you can undo
                this.originalValue = (ProductViewModel)this.MemberwiseClone();
            }
        }

        private void Delete()
        {
            productService.Delete(this.ProductId);
            //refresh the view
            //this.Container.CustomerList = this.Container.GetCustomers();
        }

        private void Undo()
        {
            if (this.Mode == Mode.Edit)
            {
                this.ProductName = originalValue.ProductName;
                this.ProductNumber = originalValue.ProductNumber;
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