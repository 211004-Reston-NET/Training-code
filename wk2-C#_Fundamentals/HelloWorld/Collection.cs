using System;
using System.Collections.Generic;

namespace CollectionFunction
{
    public class Collection
    {
        //Generic Collection
        List<string> strings = new List<string>();

        /*
        This is the default constructor that compiler gives you
        public Collection()
        {

        }
        */

        // public Collection(string someString)
        // {
        //     strings.Add(someString);
        // }

        public void CollectionMain()
        {
            Console.WriteLine("===== Collection Demo ====");
            Console.WriteLine("List Demo");

            //Adding new elements to a collection
            strings.Add("First element");
            strings.Add("Second element");
            strings.Add("Third element");

            //A way to go through a list
            //Foreach will iterate through all the elements of a collection
            Console.WriteLine("==For Each Demo==");
            foreach (string thisIsAString in strings) 
            {
                Console.WriteLine(thisIsAString);
            }

            Console.WriteLine("==For Loop Demo==");
            //For loop will help you customize a way to iterate 
            // through a list by having the tools to change the condition
            // you want the loop to stop on
            // or the way you increment the variable that is being used in that condiiton
            for (int i = 0; i < strings.Count; i+=2)
            {
                Console.WriteLine("The current i variable holds: " + i);
                Console.WriteLine(strings[i]);
            }
            
        }
    }
}