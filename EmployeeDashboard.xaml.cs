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
    public partial class EmployeeDashboard : Window
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var exitConfirmation = new ExitConfirmation();
            exitConfirmation.ShowDialog();

            if (exitConfirmation.IsConfirmed)
            {
                var login = new login();
                //login.Show();
                this.Close();
            }
        }

        private void ViewPendingQuotations_Click(object sender, RoutedEventArgs e)
        {
            var pendingQuotationsWindow = new Quotations();
            pendingQuotationsWindow.Show();
        }

    }
}
