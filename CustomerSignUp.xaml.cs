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

using System;
using IAB251_A2.Models;
using IAB251_A2.Controllers;
using IAB251_A2;
using IAB251_A2.Services;
using System.Net;

namespace front_end
{
    
    public partial class CustomerSignUp : Page
    {
        private UserController userController;

        public CustomerSignUp(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
            this.Loaded += CustomerSignUp_Loaded;
        }

        private void CustomerSignUp_Loaded(object sender, RoutedEventArgs e)
        {
            AddPlaceholderText(FirstNameTextBox, null);
            AddPlaceholderText(LastNameTextBox, null);
            AddPlaceholderText(EmailTextBox, null);
            AddPlaceholderText(PhoneTextBox, null);
            AddPlaceholderText(CompanyNameTextBox, null);
            AddPlaceholderText(AddressTextBox, null);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.ChooseSignUpType(userController));
            }
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
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            int phone;
            bool isPhoneValid = int.TryParse(PhoneTextBox.Text, out phone);
            var userService = new UserService();

            var customer = new Customer
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = phone,
                CompanyName = CompanyNameTextBox.Text,
                Address = AddressTextBox.Text,
                Password = PasswordBox.Password
            };

            if (string.IsNullOrWhiteSpace(customer.FirstName) || string.IsNullOrWhiteSpace(customer.LastName) ||
                string.IsNullOrWhiteSpace(customer.Email) || string.IsNullOrWhiteSpace(customer.Address) ||
                string.IsNullOrWhiteSpace(customer.Password) || !isPhoneValid)
            {
                MessageBox.Show("Please fill all required fields with valid data.");
                return;
            }
            string result = userController.RegisterCustomer(customer);
            MessageBox.Show(result);


            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.login(userController)); // Navigate to sign-up page
            }
        }
    }
}
