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

using System.Collections.ObjectModel;

using IAB251_A2.Models;
using IAB251_A2.Services;
using IAB251_A2.Controllers;
using IAB251_A2;
using IAB251_A2.Model;

namespace front_end
{

    public partial class RateSchedulePage : Page
    {
        public ObservableCollection<RateSchedule> RateSchedules { get; set; }

        private UserController _userController;
        private Employee _loggedInEmployee;
        public RateSchedulePage(Employee employee, UserController userController)
        {
            InitializeComponent();
            this._userController = userController;
            this._loggedInEmployee = employee;

            RateSchedules = new ObservableCollection<RateSchedule>
            {
                new RateSchedule { Type = "Walf Booking Fee", PriceFor20Feet = "$60", PriceFor40Feet = "$70" },
                new RateSchedule { Type = "Lift on/Lif Off", PriceFor20Feet = "$80", PriceFor40Feet = "$120" },
                new RateSchedule { Type = "Fumigation", PriceFor20Feet = "$220", PriceFor40Feet = "$280" },
                new RateSchedule { Type = "LCL Delivery Depot", PriceFor20Feet = "$400", PriceFor40Feet = "$500" },
                new RateSchedule { Type = "Tailgate Inspection", PriceFor20Feet = "$120", PriceFor40Feet = "$160" },
                new RateSchedule { Type = "Storage Fee", PriceFor20Feet = "$240", PriceFor40Feet = "$300" },
                new RateSchedule { Type = "Facility Fee", PriceFor20Feet = "$70", PriceFor40Feet = "$100" },
                new RateSchedule { Type = "Walf Inspection", PriceFor20Feet = "$60", PriceFor40Feet = "$90" },
                new RateSchedule { Type = "GST", PriceFor20Feet = "10%", PriceFor40Feet = "10%" }
            };

            DataContext = this;
            _userController = userController;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new front_end.EmployeeDashboard(_userController, _loggedInEmployee));
            }
            
        }

    }
}
