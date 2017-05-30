using System;

namespace WildFarm.Models.Animal
{
    public class Zebra : Mamal
    {
        public Zebra(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Console.WriteLine("Zebras are not eating that type of food!");
            }
            else
            {
                base.FoodEaten = food.Quantity;
            }
        }
    }
}
