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

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public bool Login(string email, string password)
        {
            var customer = Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName} logged in successfully as a Customer.");
                return true;
            }

            var employee = Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (employee != null)
            {
                Console.WriteLine($"{employee.FirstName} logged in successfully as an Employee.");
                return true;
            }

            Console.WriteLine("Login failed: Invalid credentials.");
            return false;
        }

        public string RegisterCustomer(Customer customer)
        {
            return _userService.RegisterCustomer(customer);
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
            _userService.RegisterEmployee(employee);
            Employees.Add(employee);
            Console.WriteLine("Employee registered successfully.");
        }

        public void SubmitQuotationRequest(string requestID, Customer customer, string source, string destination, int numberOfContainers, string natureOfPackage, string job)
        {
            var quotation = new Quotation
            {
                RequestID = int.Parse(requestID),
                CustomerEmail = customer.Email,
                Source = source,
                Destination = destination,
                NumberOfContainers = numberOfContainers,
                NatureOfPackage = natureOfPackage,
                NatureOfJob = job,
                Status = "Pending",
                DateIssued = DateTime.Now
            };

            // Assuming QuotationService is used to add the quotation
            QuotationService.Instance.SubmitQuotation(quotation);
        }


        public List<Quotation> GetAllQuotations()
        {

            return new List<Quotation>();
        }
    }
}