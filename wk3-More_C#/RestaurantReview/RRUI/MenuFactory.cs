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
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.RestaurantMenu:
                    return new RestaurantMenu();
                case MenuType.ShowRestaurant:
                    return new ShowRestaurant(new RestaurantBL(new Repository()));
                case MenuType.AddRestaurant:
                    return new AddRestaurant(new RestaurantBL(new Repository()));
                case MenuType.CurrentRestaurant:
                    return new CurrentRestaurant(new RestaurantBL(new Repository()));
                default:
                    return null;
            }
        }
    }
}