namespace RRUI
{
    public interface IFactory
    {
        /// <summary>
        /// Will give a derived/child class from IMenu interface based on the enum MenuType
        /// </summary>
        /// <param name="p_menu">This will determine what menu it will create</param>
        /// <returns>returns a derived/child class from IMenu</returns>
        IMenu GetMenu(MenuType p_menu);
    }
}