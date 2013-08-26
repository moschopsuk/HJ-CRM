using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using HJ.Modules.Customers.ViewModel;

namespace HJ.Modules.Customers.Views
{
    /// <summary>
    /// Interaction logic for CustomersListView.xaml
    /// </summary>
    public partial class CustomersListView : UserControl
    {
        public CustomersListView()
        {
            DataContext = new CustomerListViewModel();
            InitializeComponent();
        }
    }
}
