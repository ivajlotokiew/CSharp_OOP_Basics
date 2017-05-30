using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace _04.Problem_New
{
    public class StartUp
    {
        public static void Main()
        {
            var persons = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            string[] firstLine =
                Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine =
                Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < firstLine.Length; i++)
                {
                    string personName = firstLine[i].Split('=')[0];
                    decimal personMoney = decimal.Parse(firstLine[i].Split('=')[1]);

                    Person newPerson = new Person(personName, personMoney);
                    persons.Add(personName, newPerson);
                }

                for (int i = 0; i < secondLine.Length; i++)
                {
                    string nameProduct = secondLine[i].Split('=')[0];
                    decimal costProduct = decimal.Parse(secondLine[i].Split('=')[1]);

                    Product newProduct = new Product(nameProduct, costProduct);
                    products.Add(nameProduct, newProduct);
                }

                string nextLine = Console.ReadLine();

                while (nextLine != "END")
                {
                    string namePerson = nextLine.Split()[0];
                    string nameProduct = nextLine.Split()[1];

                    persons[namePerson].BuyingProduct(products[nameProduct]);

                    nextLine = Console.ReadLine();
                }
            }

            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (KeyNotFoundException ke)
            {
                Console.WriteLine(ke.Message);
            }

            foreach (var person in persons)
            {
                if (person.Value.ListOfProducts().Count == 0)
                {
                    Console.WriteLine($"{person.Key} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Key} - " +
                                      $"{string.Join(", ", person.Value.ListOfProducts().Select(st => st.Name))}");
                }
            }
        }
    }
}