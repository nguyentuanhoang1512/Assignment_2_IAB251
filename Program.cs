using as2;

namespace IAB251_A2
{
    public class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Employee> employees = new List<Employee>();

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
     //               RegisterCustomer();
                    break;
                case "2":
      //              RegisterEmployee();
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
    }