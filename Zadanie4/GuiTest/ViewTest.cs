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
        public void ProductDetailsViewModelCtorTest()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            Assert.IsNotNull(productViewModel.ProductGUID);
            Assert.IsNotNull(productViewModel.ProductID);
            Assert.IsNotNull(productViewModel.ProductReorderPoint);
            Assert.IsNotNull(productViewModel.ProductSafetyStockLevel);
        }
    }
}
