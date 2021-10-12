using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class ShowRestaurant : IMenu
    {
        private RestaurantBL _restBL;
        public ShowRestaurant(RestaurantBL p_restBL)
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
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
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