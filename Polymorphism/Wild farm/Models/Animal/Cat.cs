using System;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        public Cat(string animalName, double animalWeight, string livingRegion, string catBreed)
            : base(animalName, animalWeight, livingRegion)
        {
            this.CatBreed = catBreed;
        }

        public string CatBreed { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(Food.Food food)
        {
            base.FoodEaten = food.Quantity;
        }

        public override string ToString()
        {
            return $"Cat[{this.CatBreed}, {this.AnimalName}, " +
                   $"{this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
