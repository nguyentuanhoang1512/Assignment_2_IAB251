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
    public partial class ChooseSignUpType : Window
    {
        public ChooseSignUpType()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new login(); 
            //previousWindow.Show();
            this.Close();
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var customerSignUp = new CustomerSignUp();
            //customerSignUp.Show();
            this.Close();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeSignUp = new EmployeeSignUp();
            employeeSignUp.Show();
            this.Close();
        }
    }
}
