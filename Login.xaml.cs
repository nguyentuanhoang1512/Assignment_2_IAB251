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
using IAB251_A2.Services;

namespace front_end
{
    public partial class login : Window
    {
        private readonly AuthenticationService _authService;

        public login()
        {
            InitializeComponent();
            _authService = new AuthenticationService(new UserService());
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


            string loginResult = _authService.Login(email, password);

            if (loginResult.StartsWith("Customer"))
            {
                MessageBox.Show(loginResult);
                var customerDashboard = new CustomerDashboard();
                customerDashboard.Show();
                this.Close();
            }
            else if (loginResult.StartsWith("Employee"))
            {
                MessageBox.Show(loginResult);
                var employeeDashboard = new EmployeeDashboard();
                employeeDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }


        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            var signUpTypeWindow = new ChooseSignUpType();
            signUpTypeWindow.Show();
            this.Close();
        }
    }
}
