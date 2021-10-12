using System;

namespace RRUI
{
    public class RestaurantMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Restaurant Menu!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[3] - List of Restaurant");
            Console.WriteLine("[2] - Checkout");
            Console.WriteLine("[1] - Buy a Product");
            Console.WriteLine("[0] - Go to MainMenu");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "3":
                    return MenuType.ShowRestaurant;
                case "2":
                    return MenuType.RestaurantMenu;
                case "1":
                    return MenuType.RestaurantMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.RestaurantMenu;
            }
        }
    }
}