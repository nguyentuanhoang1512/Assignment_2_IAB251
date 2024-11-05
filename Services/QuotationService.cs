using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAB251_A2.Models;
namespace IAB251_A2.Services
{
    public class QuotationService
    {
        private static QuotationService _instance;
        public static QuotationService Instance => _instance ??= new QuotationService();
        private UserService _userService = new UserService();
        private List<Quotation> quotations = new List<Quotation>();

        public event Action QuotationsUpdated;


        public Customer GetCustomerByEmail(string email)
        {
            return _userService.GetAllCustomers().FirstOrDefault(c => c.Email == email);
        }

        public void UpdateQuotationStatus(int requestId, string status)
        {
            var quotation = quotations.FirstOrDefault(q => q.RequestID == requestId);
            if (quotation != null)
            {
                quotation.Status = status;
                QuotationsUpdated?.Invoke();
            }
        }
        public void UpdateApprovedStatus(int requestId, string status)
        {
            var quotation = quotations.FirstOrDefault(q => q.RequestID == requestId);
            if (quotation != null)
            {
                quotation.Approved = status;
                QuotationsUpdated?.Invoke();
            }
        }
        public void UpdateDiscountStatus(int requestId, bool status)
        {
            var quotation = quotations.FirstOrDefault(q => q.RequestID == requestId);
            if (quotation != null)
            {
                quotation.DiscountFlag = status;
                QuotationsUpdated?.Invoke();
            }
        }

        public string SubmitQuotation(Quotation quotation)
        {
            quotation.RequestID = quotations.Count + 1;
            quotation.Status = "Pending";
            quotation.Approved = "False";
            quotation.DiscountFlag = false; // no discount on creation
            quotation.DateIssued = DateTime.Now;
            PrepareDiscount(quotation); // Update discount price variable
            quotations.Add(quotation);
            QuotationsUpdated?.Invoke(); // Notify on new quotation
            return "Quotation submitted successfully!";
        }
        //Applying Discount to quote and updating the cost/price
        private void ApplyDiscount(Quotation quotation, double discount)
        {
            quotation.price = quotation.price * (1 - discount);

        }
        //Prepare Discount to calculate the correct percentage
        public void PrepareDiscount(Quotation quotation)
        {

            if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag || quotation.FumigationFlag))
            {
                quotation.DiscountPrice = quotation.price * (1 - 0.025); //2.5%
            }
            else if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag && quotation.FumigationFlag))
            {
                quotation.DiscountPrice = quotation.price * (1 - 0.05);  //5%
            }
            else if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag && quotation.FumigationFlag))
            {
                quotation.DiscountPrice = quotation.price * (1 - 0.1);   //10%
            }
        }
        //Check Discount to calculate the correct percentage
        public void UpdateDiscount(Quotation quotation)
        {


            if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag || quotation.FumigationFlag))
            {
                ApplyDiscount(quotation, 0.025); //2.5%
            }
            else if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag && quotation.FumigationFlag))
            {
                ApplyDiscount(quotation, 0.05);  //5%
            }
            else if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag && quotation.FumigationFlag))
            {
                ApplyDiscount(quotation, 0.1);   //10%
            }
        }

        public List<Quotation> GetQuotations() => quotations;
        public List<Quotation> GetPendingQuotations() => quotations.Where(q => q.Status == "Pending").ToList();

        public List<Quotation> GetAcceptQuotations() => quotations.Where(q => q.Status == "Accepted").ToList();


        public List<Quotation> GetNotApprovedQuotations() => quotations.Where(q => q.Approved == "False").ToList();
        public List<Quotation> GetNotDiscountedQuotations() => quotations.Where(q => (q.DiscountFlag == false && (q.NumberOfContainers > 5 && (q.FumigationFlag || q.QuarantineFlag) ) ) ).ToList();

    }



}