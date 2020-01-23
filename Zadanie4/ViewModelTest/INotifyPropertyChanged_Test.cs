using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModelTest
{
    [TestClass]
    public class INotifyPropertyChanged_Test
    {
        [TestMethod]
        public void ChangingMyPropertyWillRaiseNotifyEvent_Classic()
        {
            // Fixture setup
            bool eventWasRaised = false;
            ProductListViewModel test = new ProductListViewModel();
            test.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "SelectedProduct")
                {
                    eventWasRaised = true;
                }
            };

            // Exercise system
            test.SelectedProduct = new ProductViewModel();

            // Verify outcome
            Assert.IsTrue(eventWasRaised, "Event was raised");
        }

        [TestMethod]
        public void ViewModelBaseTest()
        {
            ProductListViewModelFixture _toTest = new ProductListViewModelFixture();
            int _PropertyChangedCount = 0;
            string _lastPropertyName = String.Empty;
            _toTest.PropertyChanged += (object sender, PropertyChangedEventArgs e) => { _PropertyChangedCount++; _lastPropertyName = e.PropertyName; };
            _toTest.TestRaisePropertyChanged("PropertyName");
            Assert.AreEqual<string>("PropertyName", _lastPropertyName);
            Assert.AreEqual<int>(1, _PropertyChangedCount);
        }
        private class ProductListViewModelFixture : ProductListViewModel
        {
            internal void TestRaisePropertyChanged(string propertyName)
            {
                base.OnPropertyChanged(propertyName);
            }
        }
    }
}
