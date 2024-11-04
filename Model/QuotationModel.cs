using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_A2.Models
{
    public enum ContainerSize
    {
        TwentyFeet,
        FortyFeet
    }

    public class Quotation
    {
        public int RequestID { get; set; }
        public string CustomerEmail { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int NumberOfContainers { get; set; }
        public string NatureOfPackage { get; set; }
        public string NatureOfJob { get; set; }
        public List<string> NatureOfJobs { get; set; }
        public string Status { get; set; }
        public string ImportExport { get; set; }       
        public string PackingUnpacking { get; set; }   
        public string QuarantineRequirements { get; set; } 
        public string CargoStorage { get; set; }       
        public string WarehousingDetails { get; set; }
        public DateTime DateIssued { get; set; }


        // New fields
        public decimal JobRate { get; set; } // For storing rate for each job type
        public bool RequiresMultiLegShipment { get; set; } // To handle multi-leg jobs
        public string DiscountCode { get; set; } // To apply discount codes to quotations

        public double price { get; set; }

        public ContainerSize SizeOfContainer { get; set; }

        //Luke's new fields

        public bool QuarantineFlag { get; set; } //True if quarantine is required
        public bool FumigationFlag { get; set; } //True if fumigation is required


    }

}