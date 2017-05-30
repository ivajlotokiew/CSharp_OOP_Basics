using System;

namespace WildFarm.Models.Animal
{
    public class Tiger : Feline
    {
        public Tiger(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Vegatable")
            {
                Console.WriteLine("Tigers are not eating that type of food!");
            }
            else
            {
                base.FoodEaten = food.Quantity;
            }
        }
    }
}
