using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_A2.Models
{
    public abstract class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }  
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }  
    }

    public class Customer : User
    {
        public string CompanyName { get; set; }
        public string Country { get; set; }
    }

    public class Employee : User
    {
        public string EmployeeType { get; set; }


        //Applying Discount to quote and updating the cost/price
        private void ApplyDiscount(Quotation quotation, double discount)
        {
            quotation.Cost = quotation.Cost * (1 - discount);
            Console.WriteLine($"Discount has been applyied! Quotation cost: {quotation.Cost}");
        }
        //Check Discount to calculate the correct percentage
        private void UpdateDiscount(Quotation quotation)
        {
            Console.WriteLine("Calculating discount...");
            if ( (quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag || quotation.FumigationFlag) ) {
                ApplyDiscount(quotation, 0.025); //2.5%
            } else if ( (quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag && quotation.FumigationFlag) ) {
                ApplyDiscount(quotation, 0.05);  //5%
            } else if ((quotation.NumberOfContainers > 5) && (quotation.QuarantineFlag && quotation.FumigationFlag)) {
                ApplyDiscount(quotation, 0.1);   //10%
            }
        }
    }

}
