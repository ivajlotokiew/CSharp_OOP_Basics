namespace ReallySimpleEngine.Contracts
{
    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string typeBehavior, IUnit unit);
    }
}