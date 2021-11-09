using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class ReviewMenu : IMenu
    {
        private IRestaurantBL _restBL;
        public ReviewMenu(IRestaurantBL p_restBL)
        {
            this._restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Reviews");
            List<Review> listOfReview = _restBL.GetAllReview(ShowRestaurant._findRestName);

            foreach (Review rev in listOfReview)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rev);
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
                    return MenuType.ReviewMenu;
            }
        }
    }
}