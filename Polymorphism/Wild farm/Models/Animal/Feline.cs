namespace WildFarm.Models.Animal
{
    public abstract class Feline : Mamal
    {
        protected Feline(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight, livingRegion)
        {
        }
    }
}
