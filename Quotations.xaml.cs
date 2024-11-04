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

using IAB251_A2.Models;
using IAB251_A2.Services;
using IAB251_A2.Controllers;
using IAB251_A2;
using IAB251_A2.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace front_end
{
    
    public partial class Quotations : Page
    {
        private readonly QuotationService _quotationService = QuotationService.Instance;
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        private UserController _userController;
        public Quotations(UserController userController)
        {
            InitializeComponent();
            _quotationService.QuotationsUpdated += RefreshQuotations;
            this._userController = userController;
            LoadQuotations();
        }

        private void LoadQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetQuotations());
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void RefreshQuotations()
        {
            Dispatcher.Invoke(() =>
            {
                QuotationsList.Clear();
                foreach (var quote in _quotationService.GetQuotations())
                {
                    QuotationsList.Add(quote);
                }
            });
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.CustomerDashboard(_userController));
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
