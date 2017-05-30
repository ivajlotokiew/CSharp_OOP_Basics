namespace ReallySimpleEngine.Contracts
{
    public interface IAttackFactory
    {
        IAttack CreateAttack(string typeAttack, IUnit unit);
    }
}