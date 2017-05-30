using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _09.Problem
{
    public class Company
    {
        public string companyName;
        public string department;
        public decimal salary;

        public Company(string companyName, string department, decimal salary)
        {
            this.companyName = companyName;
            this.department = department;
            this.salary = salary;
        }
    }

    public class Pokemon
    {
        public string pokemonName;
        public string pokemonType;

        public Pokemon(string pokemonName, string pokemonType)
        {
            this.pokemonName = pokemonName;
            this.pokemonType = pokemonType;
        }
    }

    public class Parents
    {
        public string parentName;
        public string parentBirthday;

        public Parents(string parentName, string parentBirthday)
        {
            this.parentName = parentName;
            this.parentBirthday = parentBirthday;
        }
    }

    public class Children
    {
        public string childrenName;
        public string childrenBirthday;

        public Children(string childrenName, string childrenBirthday)
        {
            this.childrenName = childrenName;
            this.childrenBirthday = childrenBirthday;
        }
    }

    public class Car
    {
        public string carModel;
        public int carSpeed;

        public Car(string carModel, int carSpeed)
        {
            this.carModel = carModel;
            this.carSpeed = carSpeed;
        }
    }

    public class Person
    {
        public string personName;
        public Company companyInfo;
        public Car carInfo;
        public List<Parents> parents;
        public List<Children> childrens;
        public List<Pokemon> pokemons;

        public Person(string personName)
        {
            this.personName = personName;
            this.parents = new List<Parents>();
            this.childrens = new List<Children>();
            this.pokemons = new List<Pokemon>();
            this.companyInfo = new Company(null, null, 0);
            this.carInfo = new Car(null, 0);
        }
    }

    public class Google
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (input != "End")
            {
                string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                InputDataPerson(data, persons);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            foreach (var person in persons)
            {
                if (person.personName == input)
                {
                    Console.WriteLine(person.personName);

                    Console.WriteLine("Company:");
                    if (person.companyInfo.companyName != null)
                    {
                        Console.WriteLine($"{person.companyInfo.companyName} " +
                                          $"{person.companyInfo.department} {person.companyInfo.salary:F2}");
                    }

                    Console.WriteLine("Car:");
                    if (person.carInfo.carModel != null)
                    {
                        Console.WriteLine($"{person.carInfo.carModel} {person.carInfo.carSpeed}");
                    }

                    Console.WriteLine("Pokemon:");
                    if (person.pokemons.Count > 0)
                    {
                        person.pokemons.Where(st => st.pokemonName != null)
                                        .ToList()
                                        .ForEach(st =>
                                        Console.WriteLine($"{st.pokemonName} {st.pokemonType}"));
                    }

                    Console.WriteLine("Parents:");
                    if (person.parents.Count > 0)
                    {
                        person.parents.Where(st => st.parentName != null)
                                    .ToList()
                                    .ForEach(st
                                    => Console.WriteLine($"{st.parentName} {st.parentBirthday}"));
                    }

                    Console.WriteLine("Children:");
                    if (person.childrens.Count > 0)
                    {
                        person.childrens.Where(st => st.childrenName != null)
                            .ToList()
                            .ForEach(st
                            => Console.WriteLine($"{st.childrenName} {st.childrenBirthday}"));
                    }
                }
            }
        }

        private static void InputDataPerson(string[] data, List<Person> persons)
        {
            string dataPerson = data[1];
            string name = data[0];

            switch (dataPerson)
            {
                case "company":
                    string companyName = data[2];
                    string departemnt = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    Company currentCompany = new Company(companyName, departemnt, salary);
                    if (persons.Any(st => st.personName == name))
                    {
                        int index = persons.FindIndex(st => st.personName == name);
                        persons[index].companyInfo = currentCompany;
                    }
                    else
                    {
                        var curPerson = new Person(name) { companyInfo = currentCompany };
                        persons.Add(curPerson);
                    }

                    break;

                case "pokemon":
                    string pokemonName = data[2];
                    string pokemonType = data[3];
                    Pokemon currentPokemon = new Pokemon(pokemonName, pokemonType);

                    if (persons.Any(st => st.personName == name))
                    {
                        int index = persons.FindIndex(st => st.personName == name);
                        persons[index].pokemons.Add(currentPokemon);
                    }
                    else
                    {
                        var curPerson = new Person(name);
                        curPerson.pokemons.Add(currentPokemon);
                        persons.Add(curPerson);
                    }

                    break;

                case "parents":
                    string parentName = data[2];
                    string parentBirthday = data[3];
                    Parents currentParent = new Parents(parentName, parentBirthday);

                    if (persons.Any(st => st.personName == name))
                    {
                        int index = persons.FindIndex(st => st.personName == name);
                        persons[index].parents.Add(currentParent);
                    }
                    else
                    {
                        var curPerson = new Person(name);
                        curPerson.parents.Add(currentParent);
                        persons.Add(curPerson);
                    }

                    break;

                case "children":
                    string childrenName = data[2];
                    string childrenBirthday = data[3];
                    Children currentChildren = new Children(childrenName, childrenBirthday);

                    if (persons.Any(st => st.personName == name))
                    {
                        int index = persons.FindIndex(st => st.personName == name);
                        persons[index].childrens.Add(currentChildren);
                    }
                    else
                    {
                        var curPerson = new Person(name);
                        curPerson.childrens.Add(currentChildren);
                        persons.Add(curPerson);
                    }

                    break;

                default:
                    string carName = data[2];
                    int carSpeed = Int32.Parse(data[3]);
                    Car car = new Car(carName, carSpeed);
                    if (persons.Any(st => st.personName == name))
                    {
                        int index = persons.FindIndex(st => st.personName == name);
                        persons[index].carInfo = car;
                    }
                    else
                    {
                        var curPerson = new Person(name) { carInfo = car };
                        persons.Add(curPerson);
                    }

                    break;
            }
        }
    }
}