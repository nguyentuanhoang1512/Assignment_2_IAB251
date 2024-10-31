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

namespace front_end
{
    
    public partial class Quotations : Page
    {
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        private UserController userController;
        public Quotations(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
            QuotationsList = new ObservableCollection<Quotation>(QuotationService.Instance.GetPendingQuotations());
            DataContext = this;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(userController)); 
            }

        }
    }

}
