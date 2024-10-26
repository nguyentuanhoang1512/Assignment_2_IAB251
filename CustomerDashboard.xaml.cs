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

namespace front_end
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : Window
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var exitConfirmation = new ExitConfirmation();
            exitConfirmation.ShowDialog();

            if (exitConfirmation.IsConfirmed)
            {
                Application.Current.Shutdown();
            }
        }

        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            // Open the request quotation form window
            var requestQuotationForm = new RequestQuotationForm();
            requestQuotationForm.Show();
        }

        private void ViewQuotationStatus_Click(object sender, RoutedEventArgs e)
        {
            // Open the quotation status view window
            var quotationStatusView = new Quotations();
            quotationStatusView.Show();
        }
    }
}
