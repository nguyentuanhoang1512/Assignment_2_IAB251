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

using IAB251_A2.Models;
using IAB251_A2.Services;
using System.Collections.ObjectModel;
using IAB251_A2.Controllers;
using IAB251_A2;

namespace front_end
{
    /// <summary>
    /// Interaction logic for ViewQuotationResponse.xaml
    /// </summary>
    public partial class ViewQuotationResponse : Page

    {
         private readonly QuotationService _quotationService = QuotationService.Instance;
        public ObservableCollection<Quotation> QuotationsList { get; set; }
        private Employee _employee;

        private UserController _userController;
        public ViewQuotationResponse(Employee _employee, UserController _userController)
        {
            
            InitializeComponent();
            this ._employee = _employee;
            this._userController = _userController;
            LoadAcceptQuotations();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(_userController, _employee));
            }

        }
       
        private void LoadAcceptQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetAcceptQuotations());
            QuotationListView.ItemsSource = QuotationsList;
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
