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
        private UserController _userController;

        public RequestQuotationForm(Customer loggedInCustomer, UserController userController)
        {
            InitializeComponent();
            _loggedInCustomer = loggedInCustomer;
            this._userController = userController;
            AddPlaceholderText(SourceTextBox, null);
            AddPlaceholderText(DestinationTextBox, null);
            AddPlaceholderText(NumberOfContainersTextBox, null);
            // AddPlaceholderText(NatureOfJobTextBox, null);
            AddPlaceholderText(QuarantineTextBox, null);
            AddPlaceholderText(CargoStorageTextBox, null);
            AddPlaceholderText(WarehousingTextBox, null);
            AddPlaceholderText(ContainerSizeTextBox, null);
            _userController = userController;
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
                mainWindow.MainFrame.Navigate(new front_end.CustomerDashboard(_userController)); // Navigate to sign-up page
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(SourceTextBox.Text) ||
                string.IsNullOrWhiteSpace(DestinationTextBox.Text) ||
                string.IsNullOrWhiteSpace(NumberOfContainersTextBox.Text) ||
                string.IsNullOrWhiteSpace(NatureOfPackageTextBox.Text) ||
                string.IsNullOrWhiteSpace(CargoStorageTextBox.Text) ||
                string.IsNullOrWhiteSpace(WarehousingTextBox.Text) ||
                ImportExportComboBox.SelectedItem == null ||
                PackingUnpackingComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields before submitting.");
                return;
            }
            ContainerSize result;
            if (ContainerSizeTextBox.Text == "20 feet")
            {
                result = 0;
            }
            else
            {
                result = (ContainerSize)1;
            }
            bool QuarantineTag = false;
            if ( !(string.IsNullOrWhiteSpace(QuarantineTextBox.Text)) )
            {
                QuarantineTag = true;
            }
            var requestedJobs = new List<string>();
            bool fumigationTag = false;
            if (cbWalfBooking.IsChecked == true) requestedJobs.Add("Walf Booking Fee");
            if (cbLiftOn.IsChecked == true) requestedJobs.Add("Lift on");
            if (cbLiftOff.IsChecked == true) requestedJobs.Add("Lift Off");
            if (cbFumigation.IsChecked == true)
            {
                requestedJobs.Add("Fumigation");
                fumigationTag = true;
            }
            if (cbLCLDelivery.IsChecked == true) requestedJobs.Add("LCL Delivery Depot");
            if (cbTailgateInspection.IsChecked == true) requestedJobs.Add("Tailgate Inspection");
            if (cbStorageFee.IsChecked == true) requestedJobs.Add("Storage Fee");
            if (cbWalfInspection.IsChecked == true) requestedJobs.Add("Walf Inspection");

            int size = 0;
            if (ContainerSizeTextBox.Text == "20 feet")
            {
                size = 20;
            }
            else if (ContainerSizeTextBox.Text == "40 feet")
            {
                size = 40;
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
                WarehousingDetails = WarehousingTextBox.Text,
                SizeOfContainer = size,
                NatureOfJobs = requestedJobs,
                QuarantineFlag = QuarantineTag,
                FumigationFlag = fumigationTag,
                

            };
            calculatePrice(newQuotation);
            
            quotationService.SubmitQuotation(newQuotation);
            MessageBox.Show("Quotation request submitted successfully!");


            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.CustomerDashboard(_userController)); // Navigate to sign-up page
            }

        }

        private void calculatePrice(Quotation quotation)
        {
            if (quotation.NatureOfJobs.Count ==0)
            {
                quotation.price = 0;
            }
            else
            {
                double tempPirce = 0;

                if (quotation.SizeOfContainer == 20)
                {
                    tempPirce += 70; // Default adding Facility Fee
                    for (int i = 0; i < quotation.NatureOfJobs.Count; i++)
                    {
                        if (quotation.NatureOfJobs[i] == "Walf Booking Fee") tempPirce += 60;
                        if (quotation.NatureOfJobs[i] == ("Lift on")) tempPirce += 80;
                        if (quotation.NatureOfJobs[i] == ("Lift off")) tempPirce += 80;
                        if (quotation.NatureOfJobs[i] == "Fumigation") tempPirce += 220;
                        if (quotation.NatureOfJobs[i] == "LCL Delivery Depot") tempPirce += 400;
                        if (quotation.NatureOfJobs[i] == "Tailgate Inspection") tempPirce += 120;
                        if (quotation.NatureOfJobs[i] == "Storage Fee") tempPirce += 240;
                        if (quotation.NatureOfJobs[i] == "Walf Inspection") tempPirce += 60;
                    }
                }else if (quotation.SizeOfContainer == 40)
                {
                    tempPirce += 100; // Default adding Facility Fee
                    for (int i = 0; i < quotation.NatureOfJobs.Count; i++)
                    {
                        if (quotation.NatureOfJobs[i] == "Walf Booking Fee") tempPirce += 70;
                        if (quotation.NatureOfJobs[i] == ("Lift on")) tempPirce += 120;
                        if (quotation.NatureOfJobs[i] == ("Lift off")) tempPirce += 120;
                        if (quotation.NatureOfJobs[i] == "Fumigation") tempPirce += 280;
                        if (quotation.NatureOfJobs[i] == "LCL Delivery Depot") tempPirce += 500;
                        if (quotation.NatureOfJobs[i] == "Tailgate Inspection") tempPirce += 160;
                        if (quotation.NatureOfJobs[i] == "Storage Fee") tempPirce += 300;
                        if (quotation.NatureOfJobs[i] == "Walf Inspection") tempPirce += 90;
                    }
                }

                tempPirce = tempPirce * 1.1; // Adding 10% GST
                quotation.price = tempPirce;
            }
        }
    }
}
