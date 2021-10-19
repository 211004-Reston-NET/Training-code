using System.Collections.Generic;
using RRModels;

namespace RRBL
{
    public interface IRestaurantBL
    {
        /// <summary>
        /// This will return a list of restaurants stored in the database
        /// It will also capitalize every name of the restaurant
        /// </summary>
        /// <returns>It will return a list of restaurants</returns>
        List<Restaurant> GetAllRestaurant();

        /// <summary>
        /// Adds a restaurant to the database
        /// </summary>
        /// <param name="p_rest">This is the restaurant we are adding</param>
        /// <returns>It returns the added restaurant</returns>
        Restaurant AddRestaurant(Restaurant p_rest);

        /// <summary>
        /// Will find multiple restaurant given a name
        /// </summary>
        /// <param name="p_name">This is the string it will check to find restaurants if their name has those letters</param>
        /// <returns>It will return restaurants it found</returns>
        List<Restaurant> GetRestaurant(string p_name);
    }
}