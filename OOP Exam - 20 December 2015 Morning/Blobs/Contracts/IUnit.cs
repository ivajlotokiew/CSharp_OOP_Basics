namespace ReallySimpleEngine.Contracts
{
    public interface IUnit : IUpdateable
    {
        string Name { get; }

        int Health { get; set; }

        int Damage { get; set; }

        string BehaviorType { get; }

        string AttackType { get; }

        int Attacking();

        void Deffending(int damage);
    }
}