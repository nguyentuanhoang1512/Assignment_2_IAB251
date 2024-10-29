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

namespace front_end
{
    public partial class CustomerSignUp : Page
    {
        private UserController userController = new UserController();

        public CustomerSignUp()
        {
            InitializeComponent();
            AddPlaceholderText(FirstNameTextBox, null);
            AddPlaceholderText(LastNameTextBox, null);
            AddPlaceholderText(EmailTextBox, null);
            AddPlaceholderText(PhoneTextBox, null);
            AddPlaceholderText(CompanyNameTextBox, null);
            AddPlaceholderText(AddressTextBox, null);
        }


        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Check if NavigationService can go back
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No previous page in the history.");
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
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            int phone;
            bool isPhoneValid = int.TryParse(PhoneTextBox.Text, out phone);
            string companyName = CompanyNameTextBox.Text;
            string address = AddressTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(password) || !isPhoneValid)
            {
                MessageBox.Show("Please fill all required fields with valid data.");
                return;
            }

            userController.RegisterCustomer(firstName, lastName, email, phone, companyName, address, password);

            var customerLogin = new login();
            //customerLogin.Show();
            //this.Close();
        }
    }
}
