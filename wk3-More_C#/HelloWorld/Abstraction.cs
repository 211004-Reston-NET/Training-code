using System;

namespace AbstractFunction
{
    public abstract class AbstractionDemo
    {
        private string _someField;

        //Abstract class has constructors even though it can't be instantiated so it can be inherited and used on the child class
        public AbstractionDemo(string p_someField)
        {
            _someField = p_someField;
            Console.WriteLine("The parent constructor has been called");
        }

        public AbstractionDemo()
        {
            
        }

        void someMethod()
        {
            Console.WriteLine("Some Method is working");
        }

        public abstract void anotherMethod();
    }

    public class AbstractImplementation : AbstractionDemo
    {
        public string someProperty { get; set; }
        //You can use the parent's class constructor function/method
        public AbstractImplementation(string p_someField) : base(p_someField)
        { 
            Console.WriteLine("The first constructor has been called");
        }

        //You can use the this keyword if you are in a constructor to re-use code from another constructor method within the class
        public AbstractImplementation(string p_someProperty, string p_someField) : this(p_someField)
        {
            Console.WriteLine("The second constructor has been called");
            this.someProperty = p_someProperty;
        }

        public override void anotherMethod()
        {
            
        }
    }
}