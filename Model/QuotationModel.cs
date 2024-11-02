using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_A2.Models
{
    public class Quotation
    {
        public int RequestID { get; set; }
        public string CustomerEmail { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int NumberOfContainers { get; set; }
        public string NatureOfPackage { get; set; }
        public string NatureOfJob { get; set; }
        public string Status { get; set; }
        public string ImportExport { get; set; }       
        public string PackingUnpacking { get; set; }   
        public string QuarantineRequirements { get; set; } 
        public string CargoStorage { get; set; }       
        public string WarehousingDetails { get; set; }
        public DateTime DateIssued { get; set; }
    }
}