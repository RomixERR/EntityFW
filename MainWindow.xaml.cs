using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Diagnostics;

namespace EntityFW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string SelectedEmail="";
        CustomersDatabaseEntities context = new CustomersDatabaseEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadBtn_Click(object sender, RoutedEventArgs e)
        {
            context.Customers.Load();
            dataGridCustomers.ItemsSource = context.Customers.Local.ToBindingList();

            context.Orders.Load();
            dataGridOrders.ItemsSource = context.Orders.Local.ToBindingList();
        }

        private void btNoFilter_Click(object sender, RoutedEventArgs e)
        {
            context.Orders.Load();
            dataGridOrders.ItemsSource = context.Orders.Local.ToBindingList();
        }

        private void btEmailFilter_Click(object sender, RoutedEventArgs e)
        {
            context.Orders.Load();
            dataGridOrders.ItemsSource = context.Orders.Where((x) => x.Email == SelectedEmail).ToList();
        }

        private void dataGridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            var customer = dg.SelectedItem as Customers;
            if (customer == null) return;
            SelectedEmail = customer.Email;
            //Debug.WriteLine(customer.Email);
        }
    }
}
