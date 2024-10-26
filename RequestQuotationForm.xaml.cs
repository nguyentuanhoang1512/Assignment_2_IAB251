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
    public partial class RequestQuotationForm : Window
    {
        public RequestQuotationForm()
        {
            InitializeComponent();
        }

        // GoBack button event handler
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new CustomerDashboard(); // Replace with actual previous window if different
            dashboard.Show();
            this.Close();
        }

        // Submit button event handler
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string source = SourceTextBox.Text;
            string destination = DestinationTextBox.Text;
            string numberOfContainers = NumberOfContainersTextBox.Text;
            string natureOfPackage = NatureOfPackageTextBox.Text;
            string natureOfJob = NatureOfJobTextBox.Text;

            // Basic validation (Example: checking if fields are not empty)
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination) ||
                string.IsNullOrWhiteSpace(numberOfContainers) || string.IsNullOrWhiteSpace(natureOfPackage) ||
                string.IsNullOrWhiteSpace(natureOfJob))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Further processing or saving the data as per your application logic
            MessageBox.Show("Quotation request submitted successfully!");
        }
    }
}
