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
    }
}