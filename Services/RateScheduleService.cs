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
            return new List<RateSchedule>
        {
            new RateSchedule
            {
                Origin = "New York",
                Destination = "London",
                RatePerContainer = 1500.00m,
                Currency = "USD",
                EffectiveDate = DateTime.Now.AddDays(-30),
                ExpiryDate = DateTime.Now.AddMonths(1)
            },
            // Add more mock data or fetch from a real data source
        };
        }
    }

}
