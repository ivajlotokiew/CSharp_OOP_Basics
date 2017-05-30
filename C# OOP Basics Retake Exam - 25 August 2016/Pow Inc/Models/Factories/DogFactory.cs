namespace ReallySimpleEngine.Models.Factories
{
    using System;
    using ReallySimpleEngine.Contracts;
    using ReallySimpleEngine.Models.Animals;

    public class DogFactory : IFactoryDog
    {
        public IAnimal RegisterDog(string name, int age,
            int learnedCommands, string adoptionCenterName)
        {
            return new Dog(name, age, learnedCommands);
        }
    }
}
