using System;
using AbstractFunction;
using CollectionFunction;
using HouseFunction; //You have to add the namespace from the House class to use the House class
using OOPFunction;
using Serialize;
// This is a comment

/*
    Will be a comment
    - We use PascelCase for the most part and that means naming artifcats as EverythingWillBeCapitalized
    - We use camelCase for naming fields and that means naming artifacts as onlyOnceYouHaveALowerCaseWordAtTheBeginning
*/

namespace HelloWorld
{
    class Program
    {
        /*
            - Main method is the first method that will be called/run. (The compiler will look for this method)
            - static means, I don't have to instantiate the program class to use that method
            - void, the method will not give anything back
        */
        static void Main(string[] args)
        {
            //It will print the test inside the parenthesis onto the terminal
            Console.WriteLine("Hello World!");

            // This is if you don't make the method static you have to instantiate it
            // Program test = new Program(); //This will instantiate the obj
            // test.Example();

            Program.Example();

            //We instantiated an object called Stephen from the House class
            House Stephen = new House();
            // Console.WriteLine(Stephen.owner);

            //We set the properties of the house to some value
            Stephen.MiceName = "Jerry";
            Stephen.Owner = "Colin";

            //We displayed those changed values into the terminal
            Console.WriteLine(Stephen.MiceName);
            Console.WriteLine(Stephen.Owner);
            Console.WriteLine(Stephen.owner);

            //Solution to group activity to record a user input from the terminal
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine(); //ReadLine method is the same as the read CLI from the bash scripting
            Console.WriteLine($"Hello {name}! Welcome to programming!"); //This is a example of string interpolation in C#

            Collection collectionObj = new Collection();
            collectionObj.CollectionMain();

            Console.WriteLine("====To String Demo====");
            Console.WriteLine(Stephen);

            Console.WriteLine("==== Serializer Demo ====");

            Serialization serialObj = new Serialization();
            serialObj.SerialMain();

            Animal ani1 = new Animal()
            {
                Name = "Ron",
                Color = "Red"
            };
            Animal ani2 = new Animal("Stephen");
            ani1.Speak("Hello");
            Console.WriteLine(ani1.Name);
            Console.WriteLine(ani2.Name);

            Dog dog1 = new Dog();
            dog1.Speak();
            dog1.Speak("Hello");
            dog1.Speak("Hello");
            Console.WriteLine(dog1.Speak2());

            Console.WriteLine("========== Abstraction Demo ==========");
            // AbstractionDemo absDemo = new AbstractionDemo(); This will give an error because you can't instantiate an abstract or interface
            AbstractImplementation absDemo = new AbstractImplementation("test", "test2");

            Console.WriteLine("======== Non-Access Modifer Demo ========");
            House Brian = new House();
            House Danny = new House();

            Console.WriteLine($"Brian's Grass: {Brian.Grass}\nDanny's Grass: {Danny.Grass}");
            Console.WriteLine("Heat wave came into california");
            Brian.Grass = false;
            Console.WriteLine($"Brian's Grass: {Brian.Grass}\nDanny's Grass: {Danny.Grass}");
        }

        public static int Example()
        {
            return 10;
        }
    }
}
