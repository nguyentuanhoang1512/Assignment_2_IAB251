using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IAB251_A2;
using IAB251_A2.Controllers;

namespace front_end
{
    public partial class EmployeeSignUp : Page
    {
        private UserController userController;

        public EmployeeSignUp(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
            AddPlaceholderText(FirstNameTextBox, null);
            AddPlaceholderText(LastNameTextBox, null);
            AddPlaceholderText(EmailTextBox, null);
            AddPlaceholderText(PhoneTextBox, null);
            AddPlaceholderText(AddressTextBox, null);
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == textBox.Tag?.ToString())
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

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.ChooseSignUpType(userController)); // Navigate to sign-up page
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            int phoneNumber;
            bool phoneParsed = int.TryParse(PhoneTextBox.Text.Trim(), out phoneNumber);
            string employeeType = (EmployeeTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string address = AddressTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (!phoneParsed)
            {
                MessageBox.Show("Invalid phone number. Please enter a valid number.");
                return;
            }

            userController.RegisterEmployee(firstName, lastName, email, phoneNumber, employeeType, address, password);
            MessageBox.Show("Employee registered successfully!");

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard()); // Navigate to sign-up page
            }

        }
    }
}
