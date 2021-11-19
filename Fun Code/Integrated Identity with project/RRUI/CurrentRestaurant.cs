using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class CurrentRestaurant : IMenu
    {
        private IRestaurantBL _restBL;
        public CurrentRestaurant(IRestaurantBL p_restBL)
        {
            this._restBL = p_restBL;
        }

        public void Menu()
        {
            List<Restaurant> listOfRest = _restBL.GetRestaurant(ShowRestaurant._findRestName.Name);

            Console.WriteLine("This is the search result");
            foreach (Restaurant rest in listOfRest)
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
                    return MenuType.ShowRestaurant;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CurrentRestaurant;
            }
        }
    }
}