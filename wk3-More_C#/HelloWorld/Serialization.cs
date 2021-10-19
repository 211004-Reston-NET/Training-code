using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HouseFunction;

namespace Serialize
{
    public class Serialization
    {
        public string _filePath = "./House.json";

        public void SerialMain()
        {
            //Let's create a house obj
            House obj1 = new House()
            {
                MiceName = "Mickey Mouse",
                Owner = "Minnie Mouse",
                // Ghost = "Hairly Headless Nick"
            };

            House obj2 = new House()
            {
                MiceName = "Mighty Mouse",
                Owner = "Pluto",
                // Ghost = "Ghost Busters"
            };

            List<House> listOfHouses = new List<House>();
            listOfHouses.Add(obj1);
            listOfHouses.Add(obj2);

            //Serialize method will convert the obj into a string datatype
            //It will format the string in a way that JSON file understands
            //JsonSerializerOptions is a class that is designed to configure our JsonSerializer to do other operations
            string _jsonString = JsonSerializer.Serialize(listOfHouses,new JsonSerializerOptions{WriteIndented = true});
            Console.WriteLine(_jsonString);

            //Store our string (that is formatted in a way JSON understands) into a JSON file
            //It takes in two parameters, first on is the filepath of the file it will write to
            //Second one is the string it is going to write
            File.WriteAllText(_filePath,_jsonString);

            //==================== Now we will read from the JSON file and store it in the write class it is suppose to be =========================

            //ReadAllText method will read from a file and store its contents into a string
            _jsonString = File.ReadAllText(_filePath);

            //Deserialize is a way to convert from JSON to Object
            //The <Class> is what the JSONSerializer will convert the JSON into that object
            List<House> listOfHouses2 = JsonSerializer.Deserialize<List<House>>(_jsonString);

            foreach (House item in listOfHouses2)
            {
                Console.WriteLine(item);
            }
        }
    }
}