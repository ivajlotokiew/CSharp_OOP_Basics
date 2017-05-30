using System;

namespace WildFarm.Models.Animal
{
    public class Mouse : Mamal
    {
        public Mouse(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }

        public override void Eat(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Console.WriteLine("Mouses are not eating that type of food!");
            }
            else
            {
                base.FoodEaten = food.Quantity;
            }
        }
    }
}
