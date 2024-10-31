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
        private readonly QuotationService quotationService = QuotationService.Instance;
        private UserController userController;

        public RequestQuotationForm(UserController userController)
        {
            InitializeComponent();
            this.userController = new UserController(); 
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
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.CustomerDashboard(userController)); // Navigate to sign-up page
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var newQuotation = new Quotation
            {
                Source = SourceTextBox.Text,
                Destination = DestinationTextBox.Text,
                NumberOfContainers = int.Parse(NumberOfContainersTextBox.Text),
                NatureOfPackage = NatureOfPackageTextBox.Text,
                NatureOfJob = NatureOfJobTextBox.Text
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
