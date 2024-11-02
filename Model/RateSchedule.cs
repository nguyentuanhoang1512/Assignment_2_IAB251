using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_A2.Model
{
    public class RateSchedule
    {
        public int ScheduleID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal RatePerContainer { get; set; }
        public string Currency { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
