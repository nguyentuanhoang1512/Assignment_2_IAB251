using IAB251_A2.Models;
using System.Runtime.CompilerServices;

namespace IAB251_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to Interport Cargo Services!");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Log In");
                Console.WriteLine("0. Exit");

                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    //Register Stuff
                    Console.WriteLine("Select User type");
                    Console.WriteLine("1. Customer");
                    Console.WriteLine("2. Employee");
                    Console.WriteLine("0. Back");

                    int UserTypeInput = int.Parse(Console.ReadLine());
                    
                    if (UserTypeInput == 1)
                    {
                        //Customer Register
                    } else if (UserTypeInput == 2)
                    {
                        //Employee Register
                    } 




                } else if (input == 2)
                {
                    //Log in stuff
                } else if (input == 0)
                {
                    running = false;
                }
                
            }
        }
    }
}
