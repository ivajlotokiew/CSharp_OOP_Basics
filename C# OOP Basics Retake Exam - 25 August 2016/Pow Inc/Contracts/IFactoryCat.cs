namespace ReallySimpleEngine.Contracts
{
    public interface IFactoryCat
    {
        IAnimal RegisterCat(string name, int age, 
            int intelligenceCoefficient, string adoptionCenterName);
    }
}
