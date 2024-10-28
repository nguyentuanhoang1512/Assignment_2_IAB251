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
using IAB251_A2.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace front_end
{
    public partial class Quotations : Window
    {
        private readonly QuotationService _quotationService = QuotationService.Instance;
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        public Quotations()
        {
            InitializeComponent();
            _quotationService.QuotationsUpdated += RefreshQuotations;
            LoadQuotations();
        }

        private void LoadQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetQuotations());
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void RefreshQuotations()
        {
            Dispatcher.Invoke(() =>
            {
                QuotationsList.Clear();
                foreach (var quote in _quotationService.GetQuotations())
                {
                    QuotationsList.Add(quote);
                }
            });
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Close();
        }
    }

}
