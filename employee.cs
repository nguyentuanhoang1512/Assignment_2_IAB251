using as2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace as2
{
    public class Employee : user
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int phoneNumber { get; set; }
        public string EmployeeType { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public Employee(string username, string password) : base(username, password)
        {
            this.phoneNumber = phoneNumber;
        }
    }
}
