using System.Collections.Generic;
using System.Linq;
using RRModels;

namespace RRDL
{
    public class RespositoryCloud : IRepository
    {
        private RRDatabaseContext _context;
        public RespositoryCloud(RRDatabaseContext p_context) 
        {
            _context = p_context;
        }

        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Add(p_rest);

            //This method will save the changes made to the database
            _context.SaveChanges();

            return p_rest;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            //Method Syntax
            return _context.Restaurants.ToList();


            //Query Syntax
            // var result = (from rest in _context.Restaurants
            //             select rest);

            // List<Model.Restaurant> listOfRest = new List<Model.Restaurant>();
            // foreach (var rest in result)
            // {
            //     listOfRest.Add(new Model.Restaurant(){
            //         Name = rest.RestName,
            //         State = rest.RestState,
            //         City = rest.RestCity,
            //         Id = rest.RestId
            //     });
            // }

            // return listOfRest;
        }

        public Restaurant GetRestaurantById(int p_id)
        {
            return _context.Restaurants.Find(p_id);
        }

        public List<Review> GetAllReview(Restaurant p_rest)
        {
            //Query syntax
            // var result = (from rev in _context.Reviews
            //             where rev.RestId == p_rest.Id
            //             select rev);

            // //Mapping the Queryable<Entity.Review> into a list<Model.Review>
            // List<Model.Review> listOfReview = new List<Model.Review>();
            // foreach (Entity.Review rev in result)
            // {
            //     listOfReview.Add(new Model.Review(){
            //         Id = rev.RevId,
            //         Rating = rev.RevRating,
            //         RestId = rev.RestId
            //     });
            // }

            // return listOfReview;

            //Method Syntax - since this looks cleaner
            return _context.Reviews
                .Where(rev => rev.RestId == p_rest.Id) //We find the reviews that have matching restId
                .ToList(); //Convert it into List
        }
    }
}