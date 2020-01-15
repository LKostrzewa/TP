using GUI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.View
{
    public class ProductViewDialog : IModalDialog
    {
        private ProductView view;

        void IModalDialog.BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialog().DataContext = viewModel;
        }

        void IModalDialog.ShowDialog()
        {
            GetDialog().ShowDialog();
        }

        void IModalDialog.Close()
        {
            GetDialog().Close();
        }

        private ProductView GetDialog()
        {
            if (view == null)
            {
                //create the view if the view does not exist
                view = new ProductView();
                view.Closed += new EventHandler(view_Closed);
            }
            return view;
        }

        void view_Closed(object sender, EventArgs e)
        {
            view = null;
        }

    }
}
