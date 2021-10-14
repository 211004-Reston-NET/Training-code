using System;
using System.Collections.Generic;
using RRDL;
using RRModels;

namespace RRBL
{
    /// <summary>
    /// Handles all the business logic for the our restuarant application
    /// They are in charge of further processing/sanitizing/furthur validation of data
    /// Any Logic
    /// </summary>
    public class RestaurantBL :IRestaurantBL
    {
        private IRepository _repo;
        /// <summary>
        /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// But later on the lecture, we can then switch our RRDL project to point to an actual database in the cloud and we don't have to touch anything else to
        /// have the implementation
        /// </summary>
        /// <param name="p_repo">It will pass in a Respository object</param>
        public RestaurantBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            if (p_rest.Name == null || p_rest.City == null || p_rest.State == null)
            {
                throw new Exception("You must have a value in all of the properties of the restaurant class");
            }

            return _repo.AddRestaurant(p_rest);
        }

        public List<Restaurant> GetAllRestaurant()
        {
            //Maybe my business operation needs to capitalize every name of a restaurant
            List<Restaurant> listOfRestaurant = _repo.GetAllRestaurant();
            for (int i = 0; i < listOfRestaurant.Count; i++)
            {
                listOfRestaurant[i].Name = listOfRestaurant[i].Name.ToLower(); 
            }

            return listOfRestaurant;
        }
    }
}
