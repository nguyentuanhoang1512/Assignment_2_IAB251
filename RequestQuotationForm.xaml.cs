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
            AddPlaceholderText(SourceTextBox, null);
            AddPlaceholderText(DestinationTextBox,null);
            AddPlaceholderText(NumberOfContainersTextBox, null);
            AddPlaceholderText(NatureOfPackageTextBox, null);
            AddPlaceholderText(NatureOfJobTextBox, null);
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == textBox.Tag?.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new CustomerDashboard(); // Replace with actual previous window if different
            dashboard.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string source = SourceTextBox.Text;
            string destination = DestinationTextBox.Text;
            string numberOfContainers = NumberOfContainersTextBox.Text;
            string natureOfPackage = NatureOfPackageTextBox.Text;
            string natureOfJob = NatureOfJobTextBox.Text;

            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination) ||
                string.IsNullOrWhiteSpace(numberOfContainers) || string.IsNullOrWhiteSpace(natureOfPackage) ||
                string.IsNullOrWhiteSpace(natureOfJob))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            MessageBox.Show("Quotation request submitted successfully!");
            var customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Close();
        }
    }
}
