using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RRBL;
using RRDL;

namespace RRUI
{
    /// <summary>
    /// Designed to create menu objects
    /// </summary>
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                .Build(); //Builds our configuration

            DbContextOptions<RRIdentityDbContext> options = new DbContextOptionsBuilder<RRIdentityDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Reference2DB"))
                .Options;

            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.RestaurantMenu:
                    return new RestaurantMenu();
                case MenuType.ShowRestaurant:
                    return new ShowRestaurant(new RestaurantBL(new RespositoryCloud(new RRIdentityDbContext(options))));
                case MenuType.AddRestaurant:
                    return new AddRestaurant(new RestaurantBL(new RespositoryCloud(new RRIdentityDbContext(options))));
                case MenuType.CurrentRestaurant:
                    return new CurrentRestaurant(new RestaurantBL(new RespositoryCloud(new RRIdentityDbContext(options))));
                case MenuType.ReviewMenu:
                    return new ReviewMenu(new RestaurantBL(new RespositoryCloud(new RRIdentityDbContext(options))));
                default:
                    return null;
            }
        }
    }
}