using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class ShowRestaurant : IMenu
    {
        private IRestaurantBL _restBL;
        public static string _findRestName;
        public ShowRestaurant(IRestaurantBL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Restaurant");
            List<Restaurant> listOfRestaurants = _restBL.GetAllRestaurant();

            foreach (Restaurant rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            Console.WriteLine("[1] - Search for a restaurant");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.RestaurantMenu;
                case "1":
                    Console.WriteLine("Enter a name for the Restaurant you want to find");
                    _findRestName = Console.ReadLine();
                    return MenuType.CurrentRestaurant;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowRestaurant;
            }
        }
    }
}