using System;

namespace RRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is a boolean that has either a false or true value
            //I will use this to stop the while loop
            bool repeat = true;

            //Moved the creation logic into another class called MenuFactory instead
            //To follow Single Responsibility Principle
            IFactory factory = new MenuFactory();

            //This is example of polymorphism, abstraction, and inheritance all at the same time
            //Example of Covariance
            IMenu page = factory.GetMenu(MenuType.MainMenu);

            //This is a while loop that will keep repeating until I changed the
            //repeat variable to false
            while (repeat)
            {
                //Clean the screen on the terminal
                Console.Clear();

                //IMenu interface can hold a bunch of objects as long as they inherited from
                //IMenu, this lets us dynamically change the page by having the page variable
                //Point to a different object each time
                page.Menu();
                MenuType currentPage = page.YourChoice();

                if (currentPage == MenuType.Exit)
                {
                    Console.WriteLine("You are exiting the application!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    repeat = false;
                }
                else
                {
                    page = factory.GetMenu(currentPage);
                }
            }

        }
    }
}
