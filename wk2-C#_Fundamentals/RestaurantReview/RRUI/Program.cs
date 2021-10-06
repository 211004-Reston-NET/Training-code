using System;

namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            while (repeat)
            {
                //Clean the screen on the terminal
                Console.Clear();
                Console.WriteLine("Welcome to the Restaurant");
                string userChoice;
                Console.WriteLine("[1] - Do you want to clear the screen?");
                Console.WriteLine("[2] - Do you want to exit out of the program?");
                userChoice = Console.ReadLine();

                
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("User has chosen to clear the screen");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "2":
                        repeat = false;
                        Console.WriteLine("You have exited to the program!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("What the heck did you just type, try again!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}
