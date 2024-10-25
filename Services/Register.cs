using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAB251_A2.Models;

namespace IAB251_A2.Services
{
    public class UserService
    {
        private List<Customer> customers = new List<Customer>();
        private List<Employee> employees = new List<Employee>();

        public string RegisterCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Email) || string.IsNullOrEmpty(customer.Password))
            {
                return "Email and Password are required!";
            }
            if (customers.Any(c => c.Email == customer.Email))
            {
                return "Customer with this email already exists!";
            }
            customers.Add(customer);
            return "Customer registered successfully!";
        }

        public string RegisterEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Email) || string.IsNullOrEmpty(employee.Password))
            {
                return "Email and Password are required!";
            }
            if (employees.Any(e => e.Email == employee.Email))
            {
                return "Employee with this email already exists!";
            }
            employees.Add(employee);
            return "Employee registered successfully!";
        }

        public List<Customer> GetAllCustomers() => customers;
        public List<Employee> GetAllEmployees() => employees;
    }

}
