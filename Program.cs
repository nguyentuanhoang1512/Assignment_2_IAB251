using as2;

namespace IAB251_A2
{
    public class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Employee> employees = new List<Employee>();
        static List<User> users = new List<User>();

        public static void Main()
        {
            MainScreen();
        }

        public static void MainScreen()
        {
            Console.WriteLine("Welcome to InterportCargo System");
            Console.WriteLine("1. Register as Customer");
            Console.WriteLine("2. Register as Employee");
            Console.WriteLine("3. Log in");
            Console.WriteLine("4. Submit Quotation Request");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RegisterCustomer();

                    break;
                case "2":
                    RegisterEmployee();
                    break;
                case "5":
                    //             ExitSystem();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    MainScreen();
                    break;
            }
        }

        

        public static void RegisterEmployee()
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            Console.WriteLine("User Created please add extra details");

            Employee employee = new Employee(username, password);

            Console.WriteLine("Enter first name");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter email address");
            employee.EmailAddress = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            employee.phoneNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter employee type");
            employee.EmployeeType = Console.ReadLine();
            Console.WriteLine("Enter address type");
            employee.Address = Console.ReadLine();







            employees.Add(employee);
            users.Add(employee);
        }

        public static void RegisterCustomer()
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            Console.WriteLine("User Created please add extra details");

            Customer customer = new Customer(username, password);

            Console.WriteLine("Enter first name");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Enter email address");
            customer.EmailAddress = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            customer.phoneNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter address type");
            customer.address = Console.ReadLine();


            customers.Add(customer);
            users.Add(customer);
            Console.WriteLine(customers[0].FirstName + "  " + customers[0].LastName +  " " + customers[0].EmailAddress);
        }
    }
}