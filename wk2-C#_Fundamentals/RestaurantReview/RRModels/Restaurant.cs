using System;
using System.Text.RegularExpressions;

namespace RRModels
{
    public class Restaurant
    {
        //This is a field
        private string _city;

        //This is a property that uses the field called _city
        public string City
        {
            get { return _city; }
            set 
            {
                //Main idea - this Regex will find me any number inside of my string
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    //Will give the user an exception whenever you try to set the city field with a number
                    throw new Exception("City can only hold letters!");
                }
                _city = value;
            }
        }

        public string State { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nState: {State}";
        }

    }
}
