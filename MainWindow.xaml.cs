using IAB251_A2.Controllers;
using IAB251_A2.Services;
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

namespace IAB251_A2
{

    public partial class MainWindow : Window
    {
        private UserController _userController;

        public MainWindow()
        {
            InitializeComponent();
            _userController = new UserController(new UserService());
            MainFrame.Navigate(new front_end.login(_userController)); // Load the login page initially
        }
    }
}
