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
        public List<string> Messages { get; set; } = new List<string>();
    }

    public class Employee : User
    {
        public string EmployeeType { get; set; }
    }

}