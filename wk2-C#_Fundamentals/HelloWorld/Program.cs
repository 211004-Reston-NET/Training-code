using System;
using HouseFunction; //You have to add the namespace from the House class to use the House class
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
        }

        public static int Example()
        {
            return 10;
        }
    }
}
