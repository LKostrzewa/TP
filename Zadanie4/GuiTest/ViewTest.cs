using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI.ViewModel;
using Service;

namespace GuiTest
{
    [TestClass]
    public class ViewTest
    {
        [TestMethod]
        public void ProductViewModelCtorTest()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            Assert.IsNotNull(productViewModel.ProductGUID);
            Assert.IsNotNull(productViewModel.ProductID);
            Assert.IsNotNull(productViewModel.ProductReorderPoint);
            Assert.IsNotNull(productViewModel.ProductSafetyStockLevel);
        }

        [TestMethod]
        public void ProductListViewModelCtorTest()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();
            Assert.IsNotNull(productListViewModel.ProductList);
        }

        [TestMethod]
        public void ProductListViewModelCommandsTest()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(new ProductService());
            Assert.IsTrue(productListViewModel.ShowEditCommand.CanExecute(null));
            Assert.IsTrue(productListViewModel.ShowAddCommand.CanExecute(null));
        }

        [TestMethod]
        public void ProductViewModelCommandsTest()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            Assert.IsTrue(productViewModel.UpdateCommand.CanExecute(null));
            Assert.IsTrue(productViewModel.CancelCommand.CanExecute(null));
            Assert.IsTrue(productViewModel.DeleteCommand.CanExecute(null));
            Assert.IsTrue(productViewModel.ShowEditCommand.CanExecute(null));
        }
    }
}
