using System;

namespace VarianceFunction
{
    public class Variance
    {
        public static void VarianceMain()
        {
            //Boxing Demo
            int x = 10;
            object obj = x; //The compiler will implicity/automatic convert the value into an object
            Console.WriteLine(obj);

            //Unboxing Demo
            object obj2 = 10;
            int x2 = (int)obj2; //Explicit conversion meaning you have to put that (datatype) syntax in your code to convert it
            Console.WriteLine(x2);

            //Implicit Casting
            int x3 = 10;
            double d1 = x3; //The compiler will implicitly convert the value type into a bigger value type

            //Explicit Casting
            double d2 = 100.678;
            int x4 = (int)d2; //Explicit conversion meaning you have to put that (datatype) syntax in your code to convert it
            Console.WriteLine(x4); //converting int into double lost some information
            

        }
    }
}