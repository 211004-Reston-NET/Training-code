using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RRDL;
using RRModels;
using Xunit;

namespace RRTest
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<RRDatabaseContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<RRDatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlite() method will create an inmemory database for use named Test.db
            Seed();
        }

        [Fact]
        public void GetAllRestaurantShouldReturnAllRestaurant()
        {
            using (var context = new RRDatabaseContext(_options))
            {
                 //Arrange
                IRepository repo = new RespositoryCloud(context);

                 //Act
                 List<Restaurant> test = repo.GetAllRestaurant();

                 //Assert
                 Assert.Equal(2, test.Count);
                 Assert.Equal("Stephen Restaurant", test[0].Name);
            }
        }

        [Fact]
        public void AddRestaurantShouldAddARestaurant()
        {
            //First using block will add a restaruant
            using (var context = new RRDatabaseContext(_options))
            {
                 //Arrange
                IRepository repo = new RespositoryCloud(context);
                Restaurant addedRest = new Restaurant
                {
                    Name = "Colin Restaurant",
                    City = "Dallas",
                    State = "Texas"
                };

                 //Act
                 repo.AddRestaurant(addedRest);
            }

            //Second using block will find that restaurant and see if it is similar to what we added
            //Assert
            using (RRDatabaseContext contexts = new RRDatabaseContext(_options))
            {
                Restaurant result = contexts.Restaurants.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Colin Restaurant", result.Name);
                Assert.Equal("Dallas", result.City);
                Assert.Equal("Texas", result.State);
            }
        }

        [Fact]
        public void DeleteRestaurantShouldDeleteARestaurant()
        {
            using (var context = new RRDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RespositoryCloud(context);
                Restaurant rest = context.Restaurants.Find(1);

                //Act
                repo.DeleteRestaurant(rest);
            }

            using (var context = new RRDatabaseContext(_options))
            {
                //Assert
                List<Restaurant> listOfRest = context.Restaurants.ToList();

                Assert.Single(listOfRest);
                Assert.Null(context.Restaurants.Find(1));
                Assert.Null(context.Reviews.Find(1));
            }
        }

        [Fact]
        public void GetRestuarantByIdShouldWork()
        {
            using (var context = new RRDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RespositoryCloud(context);

                //Act
                Restaurant foundRest = repo.GetRestaurantById(1);

                //Assert
                Assert.Equal("Stephen Restaurant", foundRest.Name);
            }
        }

        private void Seed()
        {
            //using block to automatically close the resource that is used to connect to this db after seeding data to it
            using (var context = new RRDatabaseContext(_options))
            {
                //We want to make sure that our inmemory db gets deleted and recreated to not have any data from previous tests
                //We want a pristine database to ensure that every tests will have the exact same database being used to execute the test
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Restaurants.AddRange
                (
                    new Restaurant
                    {
                        Name = "Stephen Restaurant",
                        City = "Houston",
                        State = "Texas",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 4,
                                Description = "It was good",
                            },
                            new Review
                            {
                                Rating = 2,
                                Description = "burnt rice"
                            }
                        }
                    },
                    new Restaurant
                    {
                        Name = "Danny Restaurant",
                        City = "Disney",
                        State = "Florida",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 5,
                                Description = "Best Tacos ever"
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}