namespace WildFarm.Models.Animal
{
    using Food;

    public abstract class Animal
    {
        protected Animal(string animalName, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalWeight = animalWeight;
        }

        public string AnimalName { get; set; }

        public string AnimalType { get; set; }

        public double AnimalWeight { get; set; }

        public int FoodEaten { get; set; }

        public abstract void MakeSound();

        public abstract void Eat(Food food);
    }
}
