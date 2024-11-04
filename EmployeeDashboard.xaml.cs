using IAB251_A2;
using IAB251_A2.Controllers;
using IAB251_A2.Models;
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


namespace front_end
{
    public partial class EmployeeDashboard : Page
    {
        private UserController _userController;
        private readonly Employee _loggedInEmployee;

        public EmployeeDashboard(UserController userController, Employee loggedInEmployee = null)
        {
            InitializeComponent();
            _loggedInEmployee = loggedInEmployee;
            this._userController = userController;

            if (_loggedInEmployee is Employee employee && employee.EmployeeType == "Quotation Officer")
            {
                ViewRateScheduleButton.IsEnabled = true;
            }
            else
            {
                ViewRateScheduleButton.IsEnabled = false;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var exitConfirmation = new ExitConfirmation();
            exitConfirmation.ShowDialog();

            if (exitConfirmation.IsConfirmed)
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.MainFrame.Navigate(new front_end.login(_userController)); 
                }
            }
        }

        private void ViewPendingQuotations_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.ReviewQuotations(_userController));
            }
        }
        private void ViewRateSchedule_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.RateSchedulePage());
            }
        }
    }
}
