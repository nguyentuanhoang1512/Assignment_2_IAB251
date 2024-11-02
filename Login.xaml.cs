using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using IAB251_A2;
using IAB251_A2.Controllers;
using IAB251_A2.Models;
using IAB251_A2.Services;
using System.Windows.Controls;
using IAB251_A2.Models;
using IAB251_A2.Controllers;

namespace front_end
{
    public partial class login : Page
    {
        private readonly AuthenticationService _authService;
        private readonly UserController userController;

        private UserController userController;

        public login(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
            var userService = new UserService();
            _authService = new AuthenticationService(userService);
            
            AddPlaceholderText(UsernameTextBox, null);
        }



        private void ClearText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }


        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();

            var user = _authService.Login(email, password);
            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (user is Customer customer)
            {
                MessageBox.Show($"Welcome, {customer.FirstName}");

                // Display any messages if present
                if (customer.Messages.Count > 0)
                {
                    string messages = string.Join("\n", customer.Messages);
                    MessageBox.Show($"Messages:\n{messages}");
                    customer.Messages.Clear();  
                }

                mainWindow.MainFrame.Navigate(new front_end.CustomerDashboard(userController));
            }

            else if (user is Employee employee)
            {
                MessageBox.Show($"Welcome, {employee.FirstName}");
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(userController));
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }



        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.ChooseSignUpType(userController)); // Navigate to sign-up page
            }
        }



        
    }
  
}
