using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace as2
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int phoneNumber { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string contry { get; set; }

        public Customer(string username, string password) : base(username, password)
        {
            this.phoneNumber = phoneNumber;
        }
    }
}