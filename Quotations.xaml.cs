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

using System.Collections.ObjectModel;

using IAB251_A2.Models;
using IAB251_A2.Services;

namespace front_end
{
    public partial class Quotations : Window
    {
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        private void LoadQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetQuotations());
            QuotationListView.ItemsSource = QuotationsList;
        }

        public Quotations()
        {
            InitializeComponent();
            QuotationsList = new ObservableCollection<Quotation>(QuotationService.Instance.GetPendingQuotations());
            DataContext = this;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Close();
        }
    }

}
