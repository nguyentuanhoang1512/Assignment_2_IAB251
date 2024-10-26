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

        public UserService()
        {
            // Mock data for testing
            customers = new List<Customer>
            {
                new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe", Password = "123", PhoneNumber = 1234567890, CompanyName = "JD Inc.", Address = "123 Main St" },
                new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "password123", PhoneNumber = 98, CompanyName = "Smith & Co.", Address = "456 Market St" }
            };

            employees = new List<Employee>
            {
                new Employee { FirstName = "Alice", LastName = "Johnson", Email = "alice.j@example.com", Password = "password123", PhoneNumber = 555, EmployeeType = "Admin", Address = "789 Park Ave" },
                new Employee { FirstName = "Bob", LastName = "Brown", Email = "bob.b@example.com", Password = "password123", PhoneNumber = 55576, EmployeeType = "Quotation Officer", Address = "101 River Rd" }
            };
        }

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