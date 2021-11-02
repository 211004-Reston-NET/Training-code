using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RRModels;

namespace RRDL
{
    //The repository class has a bunch of methods that we will use to get or store information from the database
    //Does not actually hold the data itself
    public class Repository : IRepository
    {
        //Filepath need to reference from the startup project (RRUI) and hence why we need to go back a folder and cd into RRDL
        private const string _filepath = "./../RRDL/Database/";
        private string _jsonString;

        public Restaurant AddRestaurant(Restaurant p_rest)
        {
            //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Restaurant> listOfRestaurants = GetAllRestaurant();

            //We added the new restaurant from the parameter 
            listOfRestaurants.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfRestaurants, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the restaurant.json
            File.WriteAllText(_filepath+"Restaurant.json",_jsonString);

            //Will return a restaurant object from the parameter
            return p_rest;
        }


        public List<Restaurant> GetAllRestaurant()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            
            try
            {
                 _jsonString = File.ReadAllText(_filepath+"Restaurant.json");
            }
            //This will catch a very specific exception and run the block
            catch (System.IO.FileNotFoundException)
            {
                //Added Dummy data
                Restaurant newRest = new Restaurant();
                List<Restaurant> listOfRest = new List<Restaurant>();
                listOfRest.Add(newRest);

                //Added a file to database folder
                File.WriteAllText(_filepath+"Restaurant.json", JsonSerializer.Serialize<List<Restaurant>>(listOfRest));

                //Read that file I just added
                _jsonString = File.ReadAllText(_filepath+"Restaurant.json");
            }
            //Generic SystemException will always catch any exception
            catch(SystemException var)
            {
                throw var;
            }

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Restaurant>>(_jsonString);
        }

        public List<Review> GetAllReview()
        {
            _jsonString = File.ReadAllText(_filepath+"Review.json");

            return JsonSerializer.Deserialize<List<Review>>(_jsonString);
        }

        public List<Review> GetAllReview(Restaurant p_rest)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetRestaurantById(int p_id)
        {
            throw new NotImplementedException();
        }

        public Review GetReviewById(int p_id)
        {
            throw new NotImplementedException();
        }

        public Review UpdateReview(Review p_rev)
        {
            throw new NotImplementedException();
        }
    }
}
