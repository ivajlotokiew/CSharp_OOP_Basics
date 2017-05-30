namespace ReallySimpleEngine.Contracts
{
    public interface IBlobFactory
    {
        IUnit CreateBlob(string name, int heatlh, int damage,
            string behaviorType, string attackType, IBehaviorFactory behavior, IAttackFactory attack);
    }
}