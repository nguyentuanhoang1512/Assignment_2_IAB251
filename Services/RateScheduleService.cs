using IAB251_A2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_A2.Services
{
    public class RateScheduleService
    {
        public static RateScheduleService Instance { get; } = new RateScheduleService();

        public List<RateSchedule> GetAllRateSchedules()
        {
            // Fetch rate schedules, e.g., from a database or mock data
            return new List<RateSchedule>();
        }
    }
}
