using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IAB251_A2.Controllers;

namespace front_end
{
    public partial class EmployeeSignUp : Window
    {
        private UserController _userController;

        public EmployeeSignUp()
        {
            InitializeComponent();
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
            var previousWindow = new ChooseSignUpType();
            previousWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect data from the textboxes and ComboBox
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            int phoneNumber;
            bool phoneParsed = int.TryParse(PhoneTextBox.Text.Trim(), out phoneNumber);
            string employeeType = (EmployeeTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string address = AddressTextBox.Text.Trim();
            string password = PasswordBox.Password;

            // Ensure fields are not empty and data is correct
            if (!phoneParsed)
            {
                MessageBox.Show("Invalid phone number. Please enter a valid number.");
                return;
            }

            // Register employee
            _userController.RegisterEmployee(firstName, lastName, email, phoneNumber, employeeType, address, password);
            MessageBox.Show("Employee registered successfully!");

            // Close or reset the form
            this.Close();
        }
    }
}
