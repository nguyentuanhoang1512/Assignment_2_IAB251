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
using IAB251_A2.Controllers;
using IAB251_A2;

namespace front_end
{
    public partial class DiscountPage : Page
    {
        private readonly QuotationService _quotationService = QuotationService.Instance;
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        private UserController _userController;

        private Employee _loggedInEmployee;
        public DiscountPage(Employee employee,  UserController userControler)
        {
            InitializeComponent();
            _quotationService.QuotationsUpdated += RefreshQuotations;
            this._userController = userControler;
            this._loggedInEmployee = employee;
            LoadPendingQuotations();
        }

        private void LoadPendingQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetNotDiscountedQuotations());
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void RefreshQuotations()
        {
            Dispatcher.Invoke(() =>
            {
                QuotationsList.Clear();
                foreach (var quote in _quotationService.GetNotDiscountedQuotations())
                {
                    QuotationsList.Add(quote);
                }
            });
        }

        private void AcceptDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateDiscountStatus(selectedQuotation.RequestID, true);
                _quotationService.UpdateDiscount(selectedQuotation);
                MessageBox.Show($"Discount Applied. New Cost is ${selectedQuotation.price} ");
            }
        }




        private void RemoveDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateDiscountStatus(selectedQuotation.RequestID, true);

                MessageBox.Show("Discount Request Removed");
                LoadPendingQuotations();
            }
        }



        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(_userController, _loggedInEmployee));
            }

        }

        private void QuotationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                // Navigate to the detailed page for the selected quotation
                var quotationDetailPage = new QuotationDetailPage(selectedQuotation, _userController);
                NavigationService.Navigate(quotationDetailPage);
            }
        }
    }
}