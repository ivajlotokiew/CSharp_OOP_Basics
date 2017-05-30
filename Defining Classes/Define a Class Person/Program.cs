using System;
using System.Reflection;

namespace Define_a_Class_Person
{
    public class Person
    {
        public string name;
        public int age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            Person personOne = new Person();
            Person personTwo = new Person();
            Person personThree = new Person();

            personOne.name = "Pesho";
            personOne.age = 20;
            personTwo.name = "Gosho";
            personTwo.age = 18;
            personThree.name = "Stamat";
            personThree.age = 43;
        }
    }
}