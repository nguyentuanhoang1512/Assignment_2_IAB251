using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_A2.Services
{
    public class AuthenticationService
    {
        private readonly UserService _userService;

        public AuthenticationService(UserService userService)
        {
            _userService = userService;
        }

        public string Login(string email, string password)
        {
            var customer = _userService.GetAllCustomers().FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer != null)
            {
                return $"Customer {customer.FirstName} logged in successfully!";
            }

            var employee = _userService.GetAllEmployees().FirstOrDefault(e => e.Email == email && e.Password == password);
            if (employee != null)
            {
                return $"Employee {employee.FirstName} logged in successfully!";
            }

            return "Invalid login credentials.";
        }

    }

}