namespace ReallySimpleEngine.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string sourceBuilding);
    }
}