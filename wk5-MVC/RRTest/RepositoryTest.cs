using System.Collections.Generic;
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
                 var test = repo.GetAllRestaurant();

                 //Assert
                 Assert.Equal(2, test.Count);
                 Assert.Equal("Stephen Restaurant", test[0].Name);
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