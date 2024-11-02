using IAB251_A2.Models;
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

        public User Login(string email, string password)
        {
            var customer = _userService.GetAllCustomers().FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer != null) return customer;

            var employee = _userService.GetAllEmployees().FirstOrDefault(e => e.Email == email && e.Password == password);
            return employee;
        }

    }

}

