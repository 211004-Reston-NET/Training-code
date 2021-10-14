using System;

namespace OOPFunction
{
    class Animal
    {

        private string _thisIsAField;
        //This is a constructor
        //This is the method/function it will go through when 
        //constructing the object of this class
        public Animal()
        {
            Console.WriteLine("Constructor is being called right now!");
        }

        //Constructor overloading
        public Animal(string p_name)
        {   
            this.Name = p_name;
        }

        //So a property of a class is like the current state of the object
        //It can store/read the current value of the property
        //This all depends on what accessor you put in a property
        public string Name { get; set; }

        public string Color { get; set; }

        //Methods are the way for us to establish behaviors/function of an object
        //Methods can have parameters for us to pass data in it to be used
        //Virtual keyword is used to tell the compiler that this method will be override in the child class
        public virtual void Speak(string p_speak)
        {
            Console.WriteLine("Animal said " + p_speak);
        } 
    }

    //You can inherit multiple interface but can only inherit one class
    interface Test
    {
        void Speak();
    }

    class Cat : Animal
    {

    }

    //the : is syntax we use in C# to inherit from a class
    class Dog : Animal, Test
    {
        //Method Overriding
        //It is when we change the implementation/behavior of a previous method from the parent/base class
        //the child class uses the override keyword to tell that we are override this method from the parent class
        public override void Speak(string p_speak)
        {
            Console.WriteLine("This is the other Speak = Bark! translated from "+ p_speak);
        }

        //the ? syntax allows us to have optional parameters in that we don't have to pass in data
        //You can also give it default value by adding a = syntax
        public void Speak(string p_speak, int? p_howMany = 1)
        {
            for (int i = 0; i < p_howMany; i++)
            {
                Console.WriteLine("Bark! translated from " + p_speak);
            }
        }

        //Method Overloading
        //It is when we change the implementation/behavior of a similar named method in the same class
        //They will then have different parameters and differenet behavior due to it
        public void Speak()
        {
            Console.WriteLine("Bark!");
        }

        //Cannot have different return type have the same name of another method
        public string Speak2()
        {
            return "Bark";
        }
    }

    //Example of multilevel inheritance
    class Chihuahua : Dog
    {

    }
}