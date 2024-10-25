using IAB251_A2.Models;
using IAB251_A2.Services;
using System;
using System.Collections.Generic;

namespace IAB251_A2.Controllers
{
    public class UserController
    {
        private List<Customer> Customers = new List<Customer>();
        private List<Employee> Employees = new List<Employee>();

        public bool Login(string email, string password)
        {
            var user = Customers.Cast<User>().FirstOrDefault(c => c.Email == email) ??
           Employees.Cast<User>().FirstOrDefault(e => e.Email == email);

            if (user != null && user.Password == password)
            {
                Console.WriteLine($"{user.FirstName} logged in successfully.");
                return true;
            }

            Console.WriteLine("Login failed: Invalid credentials.");
            return false;

            if (user != null && user.Password == password)
            {
                Console.WriteLine($"{user.FirstName} logged in successfully.");
                return true;
            }
            Console.WriteLine("Login failed: Invalid credentials.");
            return false;
        }

        public void RegisterCustomer(string firstName, string lastName, string email, int phoneNumber, string companyName, string address, string password)
        {
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                CompanyName = companyName,
                Address = address,
                Password = password
            };
            Customers.Add(customer);
            Console.WriteLine("Customer registered successfully.");
        }

        public void RegisterEmployee(string firstName, string lastName, string email, int phoneNumber, string employeeType, string address, string password)
        {
            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmployeeType = employeeType,
                Address = address,
                Password = password
            };
            Employees.Add(employee);
            Console.WriteLine("Employee registered successfully.");
        }

        public void SubmitQuotationRequest(string requestID, Customer customer, string source, string destination, int numberOfContainers, string natureOfPackage, JobDetails job)
        {
            QuotationRequest quotation = new QuotationRequest(requestID, customer, source, destination, numberOfContainers, natureOfPackage, job);
            quotation.SubmitQuotationRequest();
        }

        public List<QuotationRequest> GetAllQuotations()
        {

            return new List<QuotationRequest>();
        }
    }
}
