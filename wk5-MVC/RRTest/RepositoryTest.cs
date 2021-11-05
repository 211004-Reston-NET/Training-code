using Microsoft.EntityFrameworkCore;
using RRDL;
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
            
            
        }
        [Fact]
        public void GetAllRestaurantShouldReturnAllRestaurant()
        {
            
        }
    }
}