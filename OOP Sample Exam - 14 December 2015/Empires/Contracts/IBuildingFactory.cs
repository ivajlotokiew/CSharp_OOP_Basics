namespace ReallySimpleEngine.Contracts
{
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string typeBuilding);
    }
}