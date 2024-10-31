using IAB251_A2;
using IAB251_A2.Controllers;
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
    public partial class ChooseSignUpType : Page
    {
        private UserController userController;
        public ChooseSignUpType(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.login(userController)); // Navigate to sign-up page
            }
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.CustomerSignUp(userController)); // Navigate to sign-up page
            }
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeSignUp(userController)); // Navigate to sign-up page
            }
        }
    }
}
