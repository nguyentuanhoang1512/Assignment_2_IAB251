﻿using System;
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

using IAB251_A2.Models;
using IAB251_A2.Services;
using System.Collections.ObjectModel;
using IAB251_A2.Controllers;
using IAB251_A2;

namespace front_end
{
    public partial class ReviewQuotations : Page
    {
        private readonly QuotationService _quotationService = QuotationService.Instance;
        public ObservableCollection<Quotation> QuotationsList { get; set; }

        private UserController _userController;

        private Employee _loggedInEmployee;
        public ReviewQuotations(Employee employee,  UserController userControler)
        {
            InitializeComponent();
            _quotationService.QuotationsUpdated += RefreshQuotations;
            this._userController = userControler;
            this._loggedInEmployee = employee;
            LoadPendingQuotations();
        }

        private void LoadPendingQuotations()
        {
            QuotationsList = new ObservableCollection<Quotation>(_quotationService.GetNotApprovedQuotations());
            QuotationListView.ItemsSource = QuotationsList;
        }

        private void RefreshQuotations()
        {
            Dispatcher.Invoke(() =>
            {
                QuotationsList.Clear();
                foreach (var quote in _quotationService.GetPendingQuotations())
                {
                    QuotationsList.Add(quote);
                }
            });
        }

        private void AcceptQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateApprovedStatus(selectedQuotation.RequestID, "Approved");
                MessageBox.Show("Quotation Approved");
            }
        }




        private void RejectQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                _quotationService.UpdateApprovedStatus(selectedQuotation.RequestID, "Invalid");

                // Fetch the customer and add a rejection message
                var customer = _quotationService.GetCustomerByEmail(selectedQuotation.CustomerEmail);
                customer?.Messages.Add("Your quotation was invalid.");

                MessageBox.Show("Quotation Request Rejected");
                LoadPendingQuotations();
            }
        }



        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(_userController, _loggedInEmployee));
            }

        }

        private void QuotationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuotationListView.SelectedItem is Quotation selectedQuotation)
            {
                // Navigate to the detailed page for the selected quotation
                var quotationDetailPage = new QuotationDetailPage(selectedQuotation, _userController);
                NavigationService.Navigate(quotationDetailPage);
            }
        }
    }
}