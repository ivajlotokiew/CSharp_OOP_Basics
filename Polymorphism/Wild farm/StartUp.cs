using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using WildFarm.Models.Animal;
using WildFarm.Models.Food;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string inputAnimalInfo = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            Stack<Food> foods = new Stack<Food>();

            while (inputAnimalInfo != "End")
            {
                string[] animalData = inputAnimalInfo.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string animalType = animalData[0];
                string name = animalData[1];
                double weight = double.Parse(animalData[2]);
                string region = animalData[3];

                string[] foodData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string foodName = foodData[0];
                int quantity = int.Parse(foodData[1]);
                
                if (foodName == "Meat")
                {
                    foods.Push(new Meat(quantity));
                }
                else
                {
                    foods.Push(new Vegatable(quantity));
                }

                if (animalType == "Cat")
                {
                    string cName = animalData[4];
                    string breed = animalData[1];

                    Animal cat = new Cat(cName, weight, region, breed);
                    cat.Eat(foods.Pop());
                    animals.Add(cat);
                }
                else
                {
                    switch (animalType)
                    {
                        case "Tiger":
                            Animal tiger = new Tiger(name, weight, region);
                            tiger.Eat(foods.Pop());
                            animals.Add(tiger);
                            break;
                        case "Zebra":
                            Animal zebra = new Zebra(name, weight, region);
                            zebra.Eat(foods.Pop());
                            animals.Add(zebra);
                            break;
                        case "Mouse":
                            Animal mouse = new Mouse(name, weight, region);
                            mouse.Eat(foods.Pop());
                            animals.Add(mouse);
                            break;
                    }
                }

                inputAnimalInfo = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                animal.MakeSound();
               
                Console.WriteLine(animal);
            }
        }
    }
}
