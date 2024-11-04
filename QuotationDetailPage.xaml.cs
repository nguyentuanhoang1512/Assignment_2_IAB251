using IAB251_A2.Controllers;
using IAB251_A2.Models;
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
    /// <summary>
    /// QuotationDetailPage.xaml 的互動邏輯
    /// </summary>
    public partial class QuotationDetailPage : Page
    {
        private Quotation _quotation;
        private UserController _userController;

        public QuotationDetailPage(Quotation quotation, UserController userController)
        {
            InitializeComponent();
            _quotation = quotation;
            _userController = userController;
            this.DataContext = _quotation; // Bind the quotation to the page
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
