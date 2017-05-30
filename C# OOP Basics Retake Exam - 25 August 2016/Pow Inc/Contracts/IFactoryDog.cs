namespace ReallySimpleEngine.Contracts
{
    public interface IFactoryDog
    {
        IAnimal RegisterDog(string name, int age, 
            int learnedCommands, string adoptionCenterName);
    }
}
