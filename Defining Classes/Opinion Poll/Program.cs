using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> listPerson = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] personData = input.Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                listPerson.Add(new Person
                {
                    Name = name,
                    Age = age
                });
            }

            listPerson
                .Where(dat => dat.Age > 30)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(dat => Console.WriteLine($"{dat.Name} - {dat.Age}"));
        }
    }
}