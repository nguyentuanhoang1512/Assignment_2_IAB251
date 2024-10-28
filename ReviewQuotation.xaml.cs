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

namespace front_end
{
    public partial class ReviewQuotations : Window
    {
        private readonly QuotationService _quotationService;
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        public ReviewQuotations()
        {
            InitializeComponent();
            _quotationService = QuotationService.Instance;

            // Load pending quotations
            LoadPendingQuotations();
        }

        private void LoadPendingQuotations()
        {
            var pendingQuotations = _quotationService.GetPendingQuotations();
            QuotationsList = new ObservableCollection<Quotation>(pendingQuotations);
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeDashboard = new EmployeeDashboard();
            EmployeeDashboard.Show();
            this.Close();
        }

        private void AcceptQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateQuotationStatus(selectedQuotation.RequestID, "Accepted");
                MessageBox.Show("Quotation Accepted");
                LoadPendingQuotations(); 
            }
        }


        private void RejectQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateQuotationStatus(selectedQuotation.RequestID, "Rejected");
                MessageBox.Show("Quotation Rejected");
                LoadPendingQuotations();
            }
            else
            {
                MessageBox.Show("Please select a quotation to reject.");
            }
        }
    }
}
