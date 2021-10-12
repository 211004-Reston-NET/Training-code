using System;
using RRBL;
using RRModels;

namespace RRUI
{
    public class AddRestaurant : IMenu
    {
        private static Restaurant _rest = new Restaurant();
        private IRestaurantBL _restBL;
         
        public AddRestaurant(IRestaurantBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Restaurant");
            Console.WriteLine("Name - " + _rest.Name);
            Console.WriteLine("State - "+ _rest.State);
            Console.WriteLine("City - "+ _rest.City);
            Console.WriteLine("[4] - Add Restaurant");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for State");
            Console.WriteLine("[1] - Input value for City");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    _restBL.AddRestaurant(_rest);
                    return MenuType.RestaurantMenu;
                case "3":
                    Console.WriteLine("Type in the value for the Name");
                    _rest.Name = Console.ReadLine();
                    return MenuType.AddRestaurant;
                case "2":
                    Console.WriteLine("Type in the value for the State");
                    _rest.State = Console.ReadLine();
                    return MenuType.AddRestaurant;
                case "1":
                    Console.WriteLine("Type in the value for the City");
                    _rest.City = Console.ReadLine();
                    return MenuType.AddRestaurant;
                case "0":
                    return MenuType.RestaurantMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowRestaurant;
            }
        }
    }
}