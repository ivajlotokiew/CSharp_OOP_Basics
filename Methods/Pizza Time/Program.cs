using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace _09.Problem
{
    public class Pizza
    {
        public string pizzaName;
        public int pizzaGroup;

        public SortedDictionary<int, HashSet<string>> DataMethod(params string[] pizzasInfo)
        {
            var pizzasDictionary = new SortedDictionary<int, HashSet<string>>();
            int index = 2;
            int key = 0;

            for (int i = 0; i < pizzasInfo.Length; i++)
            {
                if (index % 2 == 0)
                {
                    key = int.Parse(pizzasInfo[i]);
                    index++;
                    continue;
                }

                string value = pizzasInfo[i];

                if (!pizzasDictionary.ContainsKey(key))
                {
                    pizzasDictionary.Add(key, new HashSet<string>());
                }

                pizzasDictionary[key].Add(value);
                index++;
            }

            return pizzasDictionary;
        }
    }

    public class PizzaTime
    {
        public static void Main()
        {
            var output = new SortedDictionary<int, HashSet<string>>();
            MethodInfo[] methods = typeof(Pizza).GetMethods();

            bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Pizza pizzas = new Pizza();
            Regex regex = new Regex(@"([\d]+)([^\d\s]+)");
            List<string> symbols = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                Match match = regex.Match(input[i]);
                if (match.Length > 0)
                {
                    symbols.Add(match.Groups[1].Value);
                    symbols.Add(match.Groups[2].Value);
                }
            }

            output = pizzas.DataMethod(symbols.ToArray());
            StringBuilder outputBuilder = new StringBuilder();

            foreach (KeyValuePair<int, HashSet<string>> keyValuePair in output)
            {
                outputBuilder.Append($"{keyValuePair.Key} - ");
                outputBuilder.Append($"{string.Join(", ", keyValuePair.Value)}");

                Console.WriteLine(outputBuilder);

                outputBuilder.Clear();
            }
        }
    }
}