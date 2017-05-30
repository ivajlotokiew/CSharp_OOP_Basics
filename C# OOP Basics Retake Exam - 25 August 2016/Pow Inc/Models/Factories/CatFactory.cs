namespace ReallySimpleEngine.Models.Factories
{
    using System;
    using ReallySimpleEngine.Contracts;
    using Animals;

    public class CatFactory : IFactoryCat
    {
        public IAnimal RegisterCat(string name, int age, 
            int intelligenceCoefficient, string adoptionCenterName)
        {
            return new Cat(name, age, intelligenceCoefficient);
        }
    }
}
