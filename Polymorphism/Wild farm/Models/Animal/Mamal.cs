using System.Globalization;

namespace WildFarm.Models.Animal
{
    public abstract class Mamal : Animal
    {
        protected Mamal(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, " +
                   $"{this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
