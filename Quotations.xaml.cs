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

namespace front_end
{
    public partial class Quotations : Window
    {
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        public Quotations()
        {
            InitializeComponent();
            QuotationsList = new ObservableCollection<Quotation>
            {
                new Quotation { RequestID = "Q1", DateIssued = "10/10/2024" },
                new Quotation { RequestID = "Q2", DateIssued = "10/12/2024" }
            };
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void AcceptQuotation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Quotation Accepted");
        }

        private void RejectQuotation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Quotation Rejected");
        }

        private void BackToDashboard_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new EmployeeDashboard();
            dashboard.Show();
            this.Close();
        }
    }

    public class Quotation
    {
        public string RequestID { get; set; }
        public string DateIssued { get; set; }
    }
}
