using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Review> GetAllReview(Restaurant p_rest)
        {
            return _repo.GetAllReview(p_rest);
        }

        public List<Restaurant> GetRestaurant(string p_name)
        {
            List<Restaurant> listOfRestaurant = _repo.GetAllRestaurant();
            
            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            //ToLower will lowercase the string to make it not case sensitive
            return listOfRestaurant.Where(rest => rest.Name.ToLower().Contains(p_name.ToLower())).ToList();
        }

        public Restaurant GetRestaurantById(int p_Id)
        {
            Restaurant restFound = _repo.GetRestaurantById(p_Id);

            if (restFound == null)
            {
                throw new Exception("Restaurant was not found!");
            }

            return restFound;
        }

        
    }
}
