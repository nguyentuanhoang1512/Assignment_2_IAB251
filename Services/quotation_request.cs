using System;
using IAB251_A2.Models;

namespace IAB251_A2.Services
{
    public class QuotationRequest
    {
        public string RequestID { get; set; }
        public Customer Customer { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int NumberOfContainers { get; set; }
        public string NatureOfPackage { get; set; }
        public JobDetails Job { get; set; }

        public QuotationRequest(string requestID, Customer customer, string source, string destination, int numberOfContainers, string natureOfPackage, JobDetails job)
        {
            RequestID = requestID;
            Customer = customer;
            Source = source;
            Destination = destination;
            NumberOfContainers = numberOfContainers;
            NatureOfPackage = natureOfPackage;
            Job = job;
        }

        public void SubmitQuotationRequest()
        {
            Console.WriteLine("Quotation Request Submitted Successfully.");
            Console.WriteLine($"Request ID: {RequestID}");
            Console.WriteLine($"Customer: {Customer.FirstName} {Customer.LastName}");
            Console.WriteLine($"Email: {Customer.Email}");
            Console.WriteLine($"Phone: {Customer.PhoneNumber}");
            Console.WriteLine($"Company: {Customer.CompanyName}");
            Console.WriteLine($"Address: {Customer.Address}, {Customer.Country}");
            Console.WriteLine($"Source: {Source}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"Number of Containers: {NumberOfContainers}");
            Console.WriteLine($"Nature of Package: {NatureOfPackage}");
            Console.WriteLine($"Job Details: {Job.GetJobDescription()}");
        }
    }

    public class JobDetails
    {
        public bool IsImport { get; set; }
        public bool IsExport { get; set; }
        public bool IsPackingRequired { get; set; }
        public bool IsUnpackingRequired { get; set; }
        public bool HasQuarantineRequirements { get; set; }

        public JobDetails(bool isImport, bool isExport, bool isPackingRequired, bool isUnpackingRequired, bool hasQuarantineRequirements)
        {
            IsImport = isImport;
            IsExport = isExport;
            IsPackingRequired = isPackingRequired;
            IsUnpackingRequired = isUnpackingRequired;
            HasQuarantineRequirements = hasQuarantineRequirements;
        }

        public string GetJobDescription()
        {
            return $"Import: {IsImport}, Export: {IsExport}, Packing: {IsPackingRequired}, Unpacking: {IsUnpackingRequired}, Quarantine: {HasQuarantineRequirements}";
        }
    }
}