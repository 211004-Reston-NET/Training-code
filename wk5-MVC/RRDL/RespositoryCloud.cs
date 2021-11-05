using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RRModels;
using Entity = RRDL.Entities;
using Model = RRModels;

namespace RRDL
{
    public class RespositoryCloud : IRepository
    {
        private Entity.RRDatabaseContext _context;
        public RespositoryCloud(Entity.RRDatabaseContext p_context) 
        {
            _context = p_context;
        }

        public Model.Restaurant AddRestaurant(Model.Restaurant p_rest)
        {
            _context.Restaurants.Add
            (
                new Entity.Restaurant()
                {
                    RestName = p_rest.Name,
                    RestCity = p_rest.City,
                    RestState = p_rest.State
                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return p_rest;
        }

        public List<Model.Restaurant> GetAllRestaurant()
        {
            //Method Syntax
            return _context.Restaurants.Select(rest => 
                new Model.Restaurant()
                {
                    Name = rest.RestName,
                    State = rest.RestState,
                    City = rest.RestCity,
                    Id = rest.RestId
                }
            ).ToList();


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

        public Model.Restaurant GetRestaurantById(int p_id)
        {
            Entity.Restaurant restToFind = _context.Restaurants.Find(p_id);
            
            return new Model.Restaurant(){
                Id = restToFind.RestId,
                Name = restToFind.RestName,
                State = restToFind.RestState,
                City = restToFind.RestCity,
                //This is the super ugly code that I avoided during demo that you need right now
                //So if you are lazy instead of doing a mapper class
                //This is all you need to do
                //Select statement to convert each element to Model.Review
                //ToList to convert it into a List collection instead of IEnumerable
                Reviews = restToFind.Reviews.Select(rev => new Model.Review(){ 
                    Id = rev.RevId,
                    Rating = rev.RevRating
                }).ToList()
            };
        }

        public List<Model.Review> GetAllReview(Model.Restaurant p_rest)
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
                .Select(rev => new Model.Review(){ //Convert it into Model.Review
                  Id = rev.RevId,
                  Rating = rev.RevRating,
                  Restaurant = p_rest
                })
                .ToList(); //Convert it into List
        }

        public Model.Review GetReviewById(int p_id)
        {
            Entity.Review revFound = _context.Reviews
                                        .AsNoTracking() //This makes it so it stops tracking the entity once it finds the review
                                        .FirstOrDefault(rev => rev.RevId == p_id);

            return new Model.Review()
            {
                Id = revFound.RevId,
                Rating = revFound.RevRating,
                RestId = revFound.RestId
            };
        }

        public Model.Review UpdateReview(Model.Review p_rev)
        {
            //Converts Model Review into Entity Review
            Entity.Review revUpdated = new Entity.Review() 
            {
                RevId = p_rev.Id,
                RevRating = p_rev.Rating,
                RestId = p_rev.RestId
            };

            //Updates the Entity Review based on the current Id it has
            //Checks other properties of entity to see if they changed
            //If they changed it will update it
            _context.Reviews.Update(revUpdated);

            //Save the changes of the review
            _context.SaveChanges();

            return p_rev;
        }
    }
}