using IAB251_A2.Services;
﻿using IAB251_A2.Models;
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
using System.Windows.Controls;
using IAB251_A2.Controllers;
using IAB251_A2;

namespace front_end
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : Page
    {
        private Customer _currentCustomer;

        private readonly Customer _loggedInCustomer;

        public CustomerDashboard(Customer loggedInCustomer = null)
        {
            InitializeComponent();
            _loggedInCustomer = loggedInCustomer;

            if (_loggedInCustomer?.Messages?.Any() == true)
            {
                var message = string.Join("\n", _loggedInCustomer.Messages);
                MessageBox.Show(message, "Notifications");
                _loggedInCustomer.Messages.Clear();
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
                    mainWindow.MainFrame.Navigate(new front_end.login(userController)); // Navigate to sign-up page
                }
            }
        }

        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.RequestQuotationForm(userController)); // Navigate to sign-up page
            }

        }

        private void ViewQuotationStatus_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.Quotations(userController)); // Navigate to sign-up page
            }
        }


        private void DisplayMessages()
        {
            if (_currentCustomer.Messages.Any())
            {
                string messages = string.Join("\n", _currentCustomer.Messages);
                MessageBox.Show($"You have messages:\n{messages}");
                _currentCustomer.Messages.Clear(); // Optional: Clear messages after displaying
            }
        }
    }
}
