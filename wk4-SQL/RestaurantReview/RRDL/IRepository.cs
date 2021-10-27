using System.Collections.Generic;
using RRModels;

namespace RRDL
{
    public interface IRepository
    {
        /// <summary>
        /// It will add a restaurant in our database
        /// </summary>
        /// <param name="p_rest">This is the restaurant we will be adding to the database</param>
        /// <returns>It will just return the restaurant we are adding</returns>
        Restaurant AddRestaurant(Restaurant p_rest);

        /// <summary>
        /// This will return a list of restaurants stored in the database
        /// </summary>
        /// <returns>It will return a list of restaurants</returns>
        List<Restaurant> GetAllRestaurant();

        /// <summary>
        /// This will give all the reviews from a restaurant
        /// </summary>
        /// <returns>It will return a list of reviews</returns>
        List<Review> GetAllReview(Restaurant p_rest);

        /// <summary>
        /// This will give a specific restaurant based on the ID
        /// </summary>
        /// <param name="p_id">This is the ID it will look for</param>
        /// <returns>Returns the resturant it found</returns>
        Restaurant GetRestaurantById(int p_id);
    }
}