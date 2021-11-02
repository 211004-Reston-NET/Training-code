using System;
using System.Collections.Generic;
using RRBL;
using RRModels;

namespace RRUI
{
    public class ReviewMenu : IMenu
    {
        private IRestaurantBL _restBL;
        private IReviewBL _revBL;
        public ReviewMenu(IRestaurantBL p_restBL, IReviewBL p_revBL)
        {
            this._restBL = p_restBL;
            this._revBL = p_revBL;
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
            Console.WriteLine("[1] - Select a Review By Id");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.ShowRestaurant;
                case "1":
                    Console.WriteLine("Enter the Review Id you want to change");
                    try
                    {
                        //Selects one of the review
                        int revId = Int32.Parse(Console.ReadLine());
                        Review revFound = _revBL.GetReviewById(revId);

                        //Asks how much you want to add to the rating
                        Console.WriteLine("Input how much you want to add to the rating");
                        int addedRating = Int32.Parse(Console.ReadLine());

                        //Business layer UpdateReview method will update the rating
                        _revBL.UpdateReview(revFound, addedRating);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please input a number and not a character!");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.ShowRestaurant;
                    }
                    
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