using IAB251_A2;
using IAB251_A2.Controllers;
using IAB251_A2.Models;
using IAB251_A2.Services;
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
    
    public partial class RequestQuotationForm : Page
    {
        private Customer _loggedInCustomer;
        private readonly QuotationService quotationService = QuotationService.Instance;
        public RequestQuotationForm(Customer loggedInCustomer)
        {
            InitializeComponent();
            this.userController = new UserController(); 
            _loggedInCustomer = loggedInCustomer;
            AddPlaceholderText(SourceTextBox, null);
            AddPlaceholderText(DestinationTextBox,null);
            AddPlaceholderText(NumberOfContainersTextBox, null);
            AddPlaceholderText(NatureOfPackageTextBox, null);
            AddPlaceholderText(QuarantineTextBox, null);
            AddPlaceholderText(CargoStorageTextBox, null);
            AddPlaceholderText(WarehousingTextBox, null);
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
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.CustomerDashboard(userController)); // Navigate to sign-up page
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SourceTextBox.Text) ||
                string.IsNullOrWhiteSpace(DestinationTextBox.Text) ||
                string.IsNullOrWhiteSpace(NumberOfContainersTextBox.Text) ||
                string.IsNullOrWhiteSpace(NatureOfPackageTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuarantineTextBox.Text) ||
                string.IsNullOrWhiteSpace(CargoStorageTextBox.Text) ||
                string.IsNullOrWhiteSpace(WarehousingTextBox.Text) ||
                ImportExportComboBox.SelectedItem == null ||
                PackingUnpackingComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields before submitting.");
                return;
            }
            var newQuotation = new Quotation
            {
                Source = SourceTextBox.Text,
                Destination = DestinationTextBox.Text,
                NumberOfContainers = int.Parse(NumberOfContainersTextBox.Text),
                NatureOfPackage = NatureOfPackageTextBox.Text,
                ImportExport = (ImportExportComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                PackingUnpacking = (PackingUnpackingComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                QuarantineRequirements = QuarantineTextBox.Text,
                CargoStorage = CargoStorageTextBox.Text,
                WarehousingDetails = WarehousingTextBox.Text
            };

            quotationService.SubmitQuotation(newQuotation);
            MessageBox.Show("Quotation request submitted successfully!");

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(userController)); // Navigate to sign-up page
            }

        }

    }
}
