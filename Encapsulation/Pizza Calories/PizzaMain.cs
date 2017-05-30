using System.Globalization;

namespace Pizza
{
    using System;
    using System.Linq;
    using Models;

    public static class PizzaMain
    {
        public static double totalSUmCalories;

        public static void Main()
        {
            DebugRead();
        }

        public static void DebugRead()
        {
            var input = Console.ReadLine();
            var pizzaInfo = input.Split().Skip(1).ToArray();
            string pizzaName = pizzaInfo[0];
            int numberOfToppings = int.Parse(pizzaInfo[1]);

            try
            {
                var pizza = new Pizza(pizzaName, numberOfToppings);
                input = Console.ReadLine();

                while (input != "END")
                {
                    string[] line = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    string ingradientPizza = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(line[0].ToLower());

                    switch (ingradientPizza)
                    {
                        case "Dough":

                            var tokens = input.Split().Skip(1).ToArray();
                            string flourType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tokens[0]);
                            string bakingTechnique = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tokens[1]);
                            double weight = double.Parse(tokens[2]);

                            try
                            {
                                var dough = new Dough(flourType, bakingTechnique, weight);
                                totalSUmCalories += dough.CaloriesPerGram;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                            break;

                        case "Topping":
                            var toppingTokens = line.Skip(1).ToArray();
                            string toppingType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(toppingTokens[0]);
                            double toppingWeight = double.Parse(toppingTokens[1]);
                            if (numberOfToppings == 0)
                            {
                                Console.WriteLine("...");
                            }

                            numberOfToppings--;

                            try
                            {
                                var topping = new Topping(toppingType, toppingWeight);
                                totalSUmCalories += topping.CaloriesPerGram;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }

                            break;
                    }

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.PizzaName} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
