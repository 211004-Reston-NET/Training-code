using System;

namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            //This is example of polymorphism, abstraction, and inheritance all at the same time
            IMenu page = new MainMenu();

            while (repeat)
            {
                //Clean the screen on the terminal
                Console.Clear();
                
                page.Menu();
                MenuType currentPage = page.YourChoice();

                switch (currentPage)
                {
                    case MenuType.MainMenu:
                        page = new MainMenu();
                        break;
                    case MenuType.RestaurantMenu:
                        //This will point the page reference variable to a new Restaurant Object
                        //Since Restaurant Object has different implementation/function of the Menu Method
                        //It will change my terminal to reflect that change
                        page = new RestaurantMenu();
                        break; 
                    case MenuType.Exit:
                        Console.WriteLine("You are exiting the application!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("You forgot to add a menu in your enum/code");
                        repeat = false;
                        break;
                }
            }

        }
    }
}
