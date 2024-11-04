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
using System.Windows.Shapes;

using IAB251_A2.Models;
using IAB251_A2.Services;
using System.Collections.ObjectModel;
using IAB251_A2;

namespace front_end
{
    public partial class ReviewQuotations : Page
    {
        private readonly QuotationService _quotationService = QuotationService.Instance;
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        public ReviewQuotations()
        {
            InitializeComponent();
            _quotationService.QuotationsUpdated += RefreshQuotations;
            LoadPendingQuotations();
        }

        private void LoadPendingQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetPendingQuotations());
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void RefreshQuotations()
        {
            Dispatcher.Invoke(() =>
            {
                QuotationsList.Clear();
                foreach (var quote in _quotationService.GetPendingQuotations())
                {
                    QuotationsList.Add(quote);
                }
            });
        }

        private void AcceptQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateQuotationStatus(selectedQuotation.RequestID, "Accepted");
                MessageBox.Show("Quotation Accepted");
            }
        }




        private void RejectQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateQuotationStatus(selectedQuotation.RequestID, "Rejected");

                // Fetch the customer and add a rejection message
                var customer = _quotationService.GetCustomerByEmail(selectedQuotation.CustomerEmail);
                customer?.Messages.Add("Your quotation was rejected.");

                MessageBox.Show("Quotation Rejected");
                LoadPendingQuotations();
            }
        }



        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard()); 
            }

        }
    }
}