using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
    }
}
