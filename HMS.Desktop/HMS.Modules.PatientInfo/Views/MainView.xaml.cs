using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using HMS.Repository.Models;

namespace HMS.Modules.PatientInfo.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INotifyPropertyChanged
    {
        public MainView()
        {
            InitializeComponent();
            HeaderText = "Patient Module";
            var customer=new Customer();
            Customers=customer.GetCustomers();
            dtGridCustomers.ItemsSource = Customers;
            //MessageBox.Show(Customers.Count().ToString());
        }

        private string _headerText;

        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
                NotifyPropertyChanged("HeaderText");
            }
        }

        private List<HMS.ModelCore.Customer> _customers;

        public List<HMS.ModelCore.Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                NotifyPropertyChanged("Customers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
