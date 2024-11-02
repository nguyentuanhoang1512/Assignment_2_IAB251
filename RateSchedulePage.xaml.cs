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

        public RateSchedulePage()
        {
            InitializeComponent();
            RateSchedules = new ObservableCollection<RateSchedule>(RateScheduleService.Instance.GetAllRateSchedules());
            DataContext = this;
        }

        
    }
}
