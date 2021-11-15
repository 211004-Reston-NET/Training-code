using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RRModels;

namespace RRDL
{
    public class RespositoryCloud : IRepository
    {
        private RRIdentityDbContext _context; //Change to point to our new DBContext instead
        public RespositoryCloud(RRIdentityDbContext p_context) 
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

        public Review GetReviewById(int p_id)
        {
            return _context.Reviews
                        .AsNoTracking() //This makes it so it stops tracking the entity once it finds the review
                        .FirstOrDefault(rev => rev.Id == p_id);
        }

        public Review UpdateReview(Review p_rev)
        {
           
            //Updates the Entity Review based on the current Id it has
            //Checks other properties of entity to see if they changed
            //If they changed it will update it
            _context.Reviews.Update(p_rev);

            //Save the changes of the review
            _context.SaveChanges();

            return p_rev;
        }

        public Restaurant DeleteRestaurant(Restaurant p_rest)
        {
            _context.Restaurants.Remove(p_rest);
            _context.SaveChanges();
            return p_rest;
        }

        public List<Review> GetAllReviewByRestId(int p_id)
        {
            return _context.Reviews
                    .Where(rev => rev.RestId == p_id)
                    .ToList();
        }
    }
}