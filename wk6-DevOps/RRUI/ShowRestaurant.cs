using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class ShowRestaurant : IMenu
    {
        private IRestaurantBL _restBL;
        public static Restaurant _findRestName = new Restaurant();
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
            Console.WriteLine("[2] - Select Restaurant based on Id");
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
                    _findRestName.Name = Console.ReadLine();
                    return MenuType.CurrentRestaurant;
                case "2":
                    Console.WriteLine("Enter the ID of the restaurant you want to find");

                    try
                    {
                         _findRestName.Id = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please put in a number!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowRestaurant;
                    }

                    return MenuType.ReviewMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowRestaurant;
            }
        }
    }
}